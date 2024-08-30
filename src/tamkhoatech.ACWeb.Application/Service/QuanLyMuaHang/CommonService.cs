using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using tamkhoatech.ACWeb.IService.IQuanLyMuaHang;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.Service.QuanLyMuaHang
{
    public class CommonService : ApplicationService, ICommonService
    {
        public readonly ACWebDbContext _context;
        public readonly IQuyenSoService _quyenSoService;
        public readonly IPhieuChiService _phieuChiService;
        public readonly IThamSoHeThongService _thamSoHeThongService;
        public CommonService(ACWebDbContext context, IQuyenSoService quyenSoService, IPhieuChiService phieuChiService, IThamSoHeThongService thamSoHeThongService)
        {
            _context = context;
            _quyenSoService = quyenSoService;
            _phieuChiService = phieuChiService;
            _thamSoHeThongService = thamSoHeThongService;
        }

        public async Task<ApiResult> TaoPhieuChiAsync(int? id, PhieuNhapRequest request)
        {
            try
            {
                //Xóa phiếu chi đã được tạo trước đó
                var firstPhieuChi = await _context.PhieuChis.FirstOrDefaultAsync(x => x.PhieuNhapId == id && !x.IsDeleted);
                if (firstPhieuChi != null)
                    await _phieuChiService.DeleteAsync(firstPhieuChi.Id);
                //Lấy tổng tiền tương ứng với loại phiếu
                decimal? tongTien = 0;
                decimal? tongTienVND = 0;
                if (request.LoaiPhieu == SystemConstants.LoaiPhieu.PhieuNhapKhau)
                {
                    tongTien = request?.TongTienHangCp;
                    tongTienVND = request?.TongTienHangCpVND;
                }
                else
                {
                    tongTien = request?.TongTien;
                    tongTienVND = request?.TongTienVND;
                }
                //Cách lấy diễn giải
                string? dienGiai = "";
                int cach = await _thamSoHeThongService.CachLayDienGiaiKhiTaoTuDongPhieuThuChiAsync(2);
                if (cach == 0)
                {
                    if (!string.IsNullOrEmpty(request?.SoHd) && request.NgayHd.HasValue)
                        dienGiai = "Chi tiền theo hóa đơn " + request.SoHd + " ngày " + request.NgayHd?.ToString("dd/MM/yyyy");
                    else
                        dienGiai = "Chi tiền mua hàng";
                }
                else if (cach == 2)
                {
                    var ct = request?.PhieuNhapCtRequests?.FirstOrDefault();
                    dienGiai = ct?.VatTuNm ?? "Chi tiền mua hàng";
                }
                else if (cach == 3)
                {
                    StringBuilder textsBuilder = new StringBuilder();
                    if (request?.PhieuNhapCtRequests != null)
                    {
                        foreach (var data in request.PhieuNhapCtRequests)
                            textsBuilder.Append(data.VatTuNm).Append(", ");
                    }
                    else
                        textsBuilder.Append("Chi tiền mua hàng");

                    string texts = textsBuilder.ToString();
                    dienGiai = _thamSoHeThongService.GioiHanKyTu(texts, 100);
                }
                var giaoDich = await _context.DMChungs.FirstOrDefaultAsync(x => x.LoaiDM == SystemConstants.DmChung.GiaoDichChi && x.DMChungUd == "2" && !x.IsDeleted);
                var loaiThue = await _context.DMChungs.FirstOrDefaultAsync(x => x.LoaiDM == SystemConstants.DmChung.LoaiThue && x.DMChungUd == "5" && !x.IsDeleted);
                var quyenSo = await _context.QuyenSos.FirstOrDefaultAsync(x => x.MaCt == SystemConstants.LoaiPhieu.PhieuChi && x.IsUser == true && !x.IsDeleted);
                var taikhoan = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TaiKhoanUd == "1111" && !x.IsDeleted);
                string? quyenSoId = quyenSo?.SoQuyen;
                string? soPhieu = (quyenSo?.SoCtHienTai + 1).ToString();
                var phieuChiCts = new List<PhieuChiCT>();
                var tempPhieuChiCts = new List<PhieuChiCT>();
                //Tạo chi Hóa Đơn mua hàng
                if(request?.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonMuaHang)
                {
                    var hoaDonMuaHangGrs = request.HoaDonMuaHangRequests?.GroupBy(x => new { x.GhiNoTK, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (hoaDonMuaHangGrs != null)
                    {
                        foreach (var ct in hoaDonMuaHangGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuChiCt = new PhieuChiCT()
                            {
                                GhiNoTk = item?.GhiNoTK,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsNo = ct.Sum(x => x.Tien),
                                PsNoVND = ct.Sum(x => x.TienVND),
                                ThanhToan = ct.Sum(x => x.Tien),
                                ThanhToanVND = ct.Sum(x => x.TienVND),
                                ThanhToanQd = ct.Sum(x => x.TienVND),
                                LoaiThue = loaiThue?.Id,
                                DienGiai = dienGiai
                            };
                            tempPhieuChiCts.Add(phieuChiCt);
                        }
                    }
                    var hoaDonGtgtGrs = request.HoaDonRequests?.GroupBy(x => new { x.TkThue, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (hoaDonGtgtGrs != null)
                    {
                        foreach (var hd in hoaDonGtgtGrs)
                        {
                            var item = hd.FirstOrDefault();// lấy ra item đại diện
                            var phieuChiCt = new PhieuChiCT()
                            {
                                GhiNoTk = item?.TkThue,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsNo = hd.Sum(x => x.Thue),
                                PsNoVND = hd.Sum(x => x.ThueVND),
                                ThanhToan = hd.Sum(x => x.Thue),
                                ThanhToanVND = hd.Sum(x => x.ThueVND),
                                ThanhToanQd = hd.Sum(x => x.ThueVND),
                                LoaiThue = loaiThue?.Id,
                                DienGiai = $"Tiền thuế của hóa đơn {request.SoHd} ngày {request.NgayHd?.ToString("dd/MM/yyyy")}"
                            };
                            phieuChiCts.Add(phieuChiCt);
                        }
                    }
                }
                else // Tạo chi phiếu nhập khẩu và phiếu nhập mua hàng
                {
                    //Lấy các tài khoản thuộc 111
                    if (!string.IsNullOrEmpty(request?.GhiCoTkUd) && request.GhiCoTkUd.Contains("111"))
                    {
                        // Nhóm chi tiết theo Tk,Vt,...
                        var phieuNhapCtGrs = request.PhieuNhapCtRequests?.GroupBy(x => new { x.GhiNoTK, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                        var chietKhauGrs = request.PhanBoChietKhauThuongMaiRequests?.GroupBy(x => new { x.TkNo, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                        if (phieuNhapCtGrs != null)
                        {
                            foreach (var ct in phieuNhapCtGrs)
                            {
                                decimal chietKhau = 0;
                                decimal chietKhauVND = 0;
                                if (chietKhauGrs != null)
                                {
                                    foreach (var ck in chietKhauGrs)
                                    {
                                        //Lấy ra chiết khấu tương ứng
                                        if (ct.Key.GhiNoTK == ck.Key.TkNo && ct.Key.VuViecId == ck.Key.VuViecId
                                            && ct.Key.MaPhiId == ck.Key.MaPhiId && ct.Key.MaTD01 == ck.Key.MaTD01
                                            && ct.Key.MaTD02 == ck.Key.MaTD02 && ct.Key.MaTD03 == ck.Key.MaTD03)
                                        {
                                            chietKhau = ck.Sum(x => x.ChietKhau) ?? 0;
                                            chietKhauVND = ck.Sum(x => x.ChietKhauVND) ?? 0;
                                        }
                                    }
                                }
                                var item = ct.FirstOrDefault();// lấy ra item đại diện
                                var phieuChiCt = new PhieuChiCT()
                                {
                                    GhiNoTk = item?.GhiNoTK,
                                    VuViecId = item?.VuViecId,
                                    MaPhiId = item?.MaPhiId,
                                    MaTD01 = item?.MaTD01,
                                    MaTD02 = item?.MaTD02,
                                    MaTD03 = item?.MaTD03,
                                    PsNo = ct.Sum(x => x.Tien) - chietKhau,
                                    PsNoVND = ct.Sum(x => x.TienVND) - chietKhauVND,
                                    ThanhToan = ct.Sum(x => x.Tien) - chietKhau,
                                    ThanhToanVND = ct.Sum(x => x.TienVND) - chietKhauVND,
                                    ThanhToanQd = ct.Sum(x => x.TienVND) - chietKhauVND,
                                    LoaiThue = loaiThue?.Id,
                                    DienGiai = dienGiai
                                };
                                tempPhieuChiCts.Add(phieuChiCt);
                            }
                        }
                        //Trường hợp phiếu nhập mua hàng
                        if (request.LoaiPhieu == SystemConstants.LoaiPhieu.PhieuNhapMuaHang)
                        {
                            var chiPhiGrs = request.PhanBoChiPhiRequests?.GroupBy(x => new { x.TkNo, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                            if (chiPhiGrs != null)
                            {
                                foreach (var cp in chiPhiGrs)
                                {
                                    var item = cp.FirstOrDefault();// lấy ra item đại diện
                                    var phieuChiCt = new PhieuChiCT()
                                    {
                                        GhiNoTk = item?.TkNo,
                                        VuViecId = item?.VuViecId,
                                        MaPhiId = item?.MaPhiId,
                                        MaTD01 = item?.MaTD01,
                                        MaTD02 = item?.MaTD02,
                                        MaTD03 = item?.MaTD03,
                                        PsNo = cp.Sum(x => x.ChiPhi),
                                        PsNoVND = cp.Sum(x => x.ChiPhiVND),
                                        ThanhToan = cp.Sum(x => x.ChiPhi),
                                        ThanhToanVND = cp.Sum(x => x.ChiPhiVND),
                                        ThanhToanQd = cp.Sum(x => x.ChiPhiVND),
                                        LoaiThue = loaiThue?.Id,
                                        DienGiai = dienGiai
                                    };
                                    tempPhieuChiCts.Add(phieuChiCt);
                                }
                            }
                            var hoaDonGtgtGrs = request.HoaDonRequests?.GroupBy(x => new { x.TkThue, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                            if (hoaDonGtgtGrs != null)
                            {
                                foreach (var hd in hoaDonGtgtGrs)
                                {
                                    var item = hd.FirstOrDefault();// lấy ra item đại diện
                                    var phieuChiCt = new PhieuChiCT()
                                    {
                                        GhiNoTk = item?.TkThue,
                                        VuViecId = item?.VuViecId,
                                        MaPhiId = item?.MaPhiId,
                                        MaTD01 = item?.MaTD01,
                                        MaTD02 = item?.MaTD02,
                                        MaTD03 = item?.MaTD03,
                                        PsNo = hd.Sum(x => x.Thue),
                                        PsNoVND = hd.Sum(x => x.ThueVND),
                                        ThanhToan = hd.Sum(x => x.Thue),
                                        ThanhToanVND = hd.Sum(x => x.ThueVND),
                                        ThanhToanQd = hd.Sum(x => x.ThueVND),
                                        LoaiThue = loaiThue?.Id,
                                        DienGiai = $"Tiền thuế của hóa đơn {request.SoHd} ngày {request.NgayHd?.ToString("dd/MM/yyyy")}"
                                    };
                                    phieuChiCts.Add(phieuChiCt);
                                }
                            }
                        }
                    }
                    //Lấy các tài khoan thuộc 331
                    else if (!string.IsNullOrEmpty(request?.GhiCoTkUd) && request.GhiCoTkUd.Contains("331"))
                    {
                        var data = request.PhieuNhapCtRequests?.FirstOrDefault();// lấy ra item đại diện
                        var phieuChiCt = new PhieuChiCT()
                        {
                            GhiNoTk = request?.GhiCoTk,
                            VuViecId = data?.VuViecId,
                            MaPhiId = data?.MaPhiId,
                            MaTD01 = data?.MaTD01,
                            MaTD02 = data?.MaTD02,
                            MaTD03 = data?.MaTD03,
                            PsNo = tongTien,
                            PsNoVND = tongTienVND,
                            ThanhToan = tongTien,
                            ThanhToanVND = tongTienVND,
                            ThanhToanQd = tongTienVND,
                            LoaiThue = loaiThue?.Id,
                            DienGiai = dienGiai
                        };
                        tempPhieuChiCts.Add(phieuChiCt);
                    }
                }
                //Lọc các phiếu chi ct trùng nhau và sau đó tính lại PsNo
                var phieuChiCtGrs = tempPhieuChiCts.GroupBy(x => new { x.GhiNoTk, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                if (phieuChiCtGrs != null)
                {
                    foreach (var pc in phieuChiCtGrs)
                    {
                        var item = pc.FirstOrDefault();// lấy ra item đại diện
                        var phieuChiCt = new PhieuChiCT()
                        {
                            GhiNoTk = item?.GhiNoTk,
                            VuViecId = item?.VuViecId,
                            MaPhiId = item?.MaPhiId,
                            MaTD01 = item?.MaTD01,
                            MaTD02 = item?.MaTD02,
                            MaTD03 = item?.MaTD03,
                            PsNo = pc.Sum(x => x.PsNo),
                            PsNoVND = pc.Sum(x => x.PsNoVND),
                            ThanhToan = pc.Sum(x => x.PsNo),
                            ThanhToanVND = pc.Sum(x => x.PsNoVND),
                            ThanhToanQd = pc.Sum(x => x.PsNoVND),
                            LoaiThue = item?.LoaiThue,
                            DienGiai = item?.DienGiai
                        };
                        phieuChiCts.Add(phieuChiCt);
                    }
                }
                //Nếu phiếu chi ct null thì không tạo
                if (phieuChiCts.Count == 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Tạo phiếu chi không thành công do không phải tài khoản 111 hoặc 331 !" };
                }
                //Tạo phiếu chi
                var phieuChi = new PhieuChi()
                {
                    LoaiPhieu = SystemConstants.LoaiPhieu.PhieuChi,
                    ChiNhanhId = request?.ChiNhanhId,
                    GiaoDichId = giaoDich?.Id,
                    KhachHangId = request?.KhachHangId,
                    DiaChi = request?.DiaChi,
                    MaSoThue = request?.MaSoThue,
                    GhiNoTkId = request?.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonMuaHang ? request?.GhiCoTk : taikhoan?.Id,
                    DienGiai = request?.DienGiai ?? $"Chi tiền theo hóa đơn {request?.SoHd} ngày {request?.NgayHd?.ToString("dd/MM/yyyy")}",
                    QuyenSoId = quyenSoId,
                    SoPhieu = soPhieu,
                    NgayHT = request?.NgayHt,
                    NgayLap = request?.NgayLap,
                    NgoaiTeId = request?.NgoaiTeId,
                    TyGia = request?.TiGia,
                    HoaDonGTGT = 0,
                    Tien = tongTien,
                    TienVND = tongTienVND,
                    TongTien = tongTien,
                    TongTienVND = tongTienVND,
                    IsSuaTien = false,
                    IsTaoTuDong = true,
                    IsPostSC = true,
                    PhieuNhapId = id,
                    TienThue = 0,
                    TienThueVND = 0,
                    TkThue = request?.GhiCoTk,
                };
                //Tạo sổ cái
                var soCais = new List<SoCai>();
                foreach (var item in phieuChiCts)
                {
                    var soCai1 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                        MaGd = phieuChi.GiaoDichId,
                        NgayHt = phieuChi.NgayHT,
                        NgayLap = phieuChi.NgayLap,
                        SoCt = phieuChi.SoPhieu,
                        KhachHangId = phieuChi.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = phieuChi.GhiNoTkId,
                        TkDoiUng = item.GhiNoTk,
                        NgoaiTeId = phieuChi.NgoaiTeId,
                        TyGia = phieuChi.TyGia,
                        TyGiaHt = phieuChi.TyGia,
                        TyGiaHt2 = phieuChi.TyGia,
                        PhatSinhNo = 0,
                        PhatSinhCo = item.PsNo,
                        PhatSinhNoVND = 0,
                        PhatSinhCoVND = item.PsNoVND,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuChi.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.KiHieuMauHD,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuChi.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai1);
                    var soCai2 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                        MaGd = phieuChi.GiaoDichId,
                        NgayHt = phieuChi.NgayHT,
                        NgayLap = phieuChi.NgayLap,
                        SoCt = phieuChi.SoPhieu,
                        KhachHangId = phieuChi.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = item.GhiNoTk,
                        TkDoiUng = phieuChi.GhiNoTkId,
                        NgoaiTeId = phieuChi.NgoaiTeId,
                        TyGia = phieuChi.TyGia,
                        TyGiaHt = phieuChi.TyGia,
                        TyGiaHt2 = phieuChi.TyGia,
                        PhatSinhNo = item.PsNo,
                        PhatSinhCo = 0,
                        PhatSinhNoVND = item.PsNoVND,
                        PhatSinhCoVND = 0,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuChi.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.KiHieuMauHD,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuChi.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai2);
                }
                phieuChi.PhieuChiCTs = phieuChiCts;
                phieuChi.SoCais = soCais;
                await _context.PhieuChis.AddAsync(phieuChi);
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();//Làm mới dbContext để đảm bảo dữ liệu đc lấy cho lần sau là mới nhất
                if (quyenSoId !=null && soPhieu != null)
                    await _quyenSoService.UpdateSoCTAsync(SystemConstants.LoaiPhieu.PhieuChi, quyenSoId, soPhieu);
                return new ApiResult() { IsSuccessed = true, Message = "Tạo phiếu chi thành công!"};
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
            
        }       
    }
}
