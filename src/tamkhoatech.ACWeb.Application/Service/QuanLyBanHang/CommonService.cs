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
using tamkhoatech.ACWeb.IService.IQuanLyBanHang;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.Service.QuanLyBanHang
{
    public class CommonService : ApplicationService, ICommonService
    {
        public readonly ACWebDbContext _context;
        public readonly IQuyenSoService _quyenSoService;
        public readonly IPhieuThuService _phieuThuService;
        public readonly IThamSoHeThongService _thamSoHeThongService;
        public CommonService(ACWebDbContext context, IQuyenSoService quyenSoService, IPhieuThuService phieuThuService, IThamSoHeThongService thamSoHeThongService)
        {
            _context = context;
            _quyenSoService = quyenSoService;
            _phieuThuService = phieuThuService;
            _thamSoHeThongService = thamSoHeThongService;
        }

        public async Task<ApiResult> TaoPhieuThuHDAAsync(int? id, PhieuXuatRequest request)
        {
            try
            {
                //Xóa phiếu thu đã được tạo trước đó
                var firstPhieuThu = await _context.PhieuThus.FirstOrDefaultAsync(x => x.PhieuXuatId == id && !x.IsDeleted);
                if (firstPhieuThu != null)
                    await _phieuThuService.DeleteAsync(firstPhieuThu.Id);
                //Cách lấy diễn giải
                string? dienGiai = "";
                int cach = await _thamSoHeThongService.CachLayDienGiaiKhiTaoTuDongPhieuThuChiAsync(1);
                if (cach == 0)
                {
                    if (!string.IsNullOrEmpty(request?.SoHd) && request.NgayHt.HasValue)
                        dienGiai = "Thu tiền theo hóa đơn " + request.SoHd + " ngày " + request.NgayHt?.ToString("dd/MM/yyyy");
                    else
                        dienGiai = "Thu tiền bán hàng";
                }
                else if (cach == 1)
                {
                    var ct = request?.PhieuXuatCtRequests?.FirstOrDefault();
                    dienGiai = ct?.VatTuNm ?? "Thu tiền bán hàng";
                }
                var phieuThuCts = new List<PhieuThuCT>();
                var tempPhieuThuCts = new List<PhieuThuCT>();
                var giaoDich = await _context.DMChungs.FirstOrDefaultAsync(x => x.LoaiDM == SystemConstants.DmChung.GiaoDichThu && x.DMChungUd == "2" && !x.IsDeleted);
                var quyenSo = await _context.QuyenSos.FirstOrDefaultAsync(x => x.MaCt == SystemConstants.LoaiPhieu.PhieuThu && x.IsUser == true && !x.IsDeleted);
                var taikhoan = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TaiKhoanUd == "1111" && !x.IsDeleted);
                string? quyenSoId = quyenSo?.SoQuyen;
                string? soPhieu = (quyenSo?.SoCtHienTai + 1).ToString();
                //Lấy các tài khoản thuộc 111
                if (!string.IsNullOrEmpty(request?.GhiNoTkUd) && request.GhiNoTkUd.Contains("111"))
                {
                    //Nhóm theo tk doanh thu
                    var tkDoanhThuGrs = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkDoanhThu, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (tkDoanhThuGrs != null)
                    {
                        foreach (var ct in tkDoanhThuGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuThuCt = new PhieuThuCT()
                            {
                                GhiCoTk = item?.TkDoanhThu,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsCo = ct.Sum(x => x.Tien),
                                PsCoVND = ct.Sum(x => x.TienVND),
                                ThanhToan = ct.Sum(x => x.Tien),
                                ThanhToanVND = ct.Sum(x => x.TienVND),
                                ThanhToanQd = ct.Sum(x => x.TienVND),
                                TienHt = ct.Sum(x => x.TienVND),
                                DienGiai = dienGiai
                            };
                            tempPhieuThuCts.Add(phieuThuCt);
                        }
                    }
                    //Nhóm theo tk thuế
                    var tkThueGrs = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkThue }).ToList();
                    if (tkThueGrs != null)
                    {
                        foreach (var ct in tkThueGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuThuCt = new PhieuThuCT()
                            {
                                GhiCoTk = item?.TkThue,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsCo = ct.Sum(x => x.Thue),
                                PsCoVND = ct.Sum(x => x.ThueVND),
                                ThanhToan = ct.Sum(x => x.Thue),
                                ThanhToanVND = ct.Sum(x => x.ThueVND),
                                ThanhToanQd = ct.Sum(x => x.ThueVND),
                                TienHt = ct.Sum(x => x.ThueVND),
                                DienGiai = $"Tiền thuế của hóa đơn {request.SoHd} ngày {request.NgayHt?.ToString("dd/MM/yyyy")}"
                            };
                            tempPhieuThuCts.Add(phieuThuCt);
                        }
                    }
                    //Nhóm theo tk chiết khấu
                    var tkChietKhauGrs = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkChietKhau, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (tkChietKhauGrs != null)
                    {
                        foreach (var ct in tkChietKhauGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuThuCt = new PhieuThuCT()
                            {
                                GhiCoTk = item?.TkChietKhau,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsCo = 0 - ct.Sum(x => x.TienCk),
                                PsCoVND = 0 - ct.Sum(x => x.TienCkVND),
                                ThanhToan = 0 - ct.Sum(x => x.TienCk),
                                ThanhToanVND = 0 - ct.Sum(x => x.TienCkVND),
                                ThanhToanQd = 0 - ct.Sum(x => x.TienCkVND),
                                TienHt = 0 - ct.Sum(x => x.TienCkVND),
                                DienGiai = dienGiai
                            };
                            tempPhieuThuCts.Add(phieuThuCt);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(request?.GhiNoTkUd) && request.GhiNoTkUd.Contains("131"))
                {
                    var phieuThuCt = new PhieuThuCT()
                    {
                        GhiCoTk = request.GhiNoTk,
                        PsCo = request.TongTien,
                        PsCoVND = request.TongTienVND,
                        ThanhToan = request.TongTien,
                        ThanhToanVND = request.TongTienVND,
                        ThanhToanQd = request.TongTienVND,
                        TienHt = request.TongTienVND,
                        DienGiai = dienGiai
                    };
                    tempPhieuThuCts.Add(phieuThuCt);
                }
                //Lọc các phiếu chi ct trùng nhau và sau đó tính lại PsNo
                var phieuThuCtGrs = tempPhieuThuCts.GroupBy(x => new { x.GhiCoTk, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                foreach (var pt in phieuThuCtGrs)
                {
                    var item = pt.FirstOrDefault();// lấy ra item đại diện
                    var phieuThuCt = new PhieuThuCT()
                    {
                        GhiCoTk = item?.GhiCoTk,
                        VuViecId = item?.VuViecId,
                        MaPhiId = item?.MaPhiId,
                        MaTD01 = item?.MaTD01,
                        MaTD02 = item?.MaTD02,
                        MaTD03 = item?.MaTD03,
                        PsCo = pt.Sum(x => x.PsCo),
                        PsCoVND = pt.Sum(x => x.PsCoVND),
                        ThanhToan = pt.Sum(x => x.PsCo),
                        ThanhToanVND = pt.Sum(x => x.PsCoVND),
                        ThanhToanQd = pt.Sum(x => x.PsCoVND),
                        TienHt = pt.Sum(x => x.PsCoVND),
                        DienGiai = item?.DienGiai
                    };
                    phieuThuCts.Add(phieuThuCt);
                }
                //Nếu phiếu thu ct null thì không tạo
                if (phieuThuCts.Count == 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Tạo phiếu thu không thành công do không phải tài khoản 111 hoặc 131 !" };
                }
                //Tạo phiếu thu
                var phieuThu = new PhieuThu()
                {
                    LoaiPhieu = SystemConstants.LoaiPhieu.PhieuThu,
                    ChiNhanhId = request?.ChiNhanhId,
                    GiaoDichId = giaoDich?.Id,
                    KhachHangId = request?.KhachHangId,
                    DiaChi = request?.DiaChi,
                    MaSoThue = request?.MaSoThue,
                    GhiNoTkId = request?.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonMuaHang ? request?.GhiNoTk : taikhoan?.Id,
                    DienGiai = request?.DienGiai ?? $"Thu tiền theo hóa đơn {request?.SoHd} ngày {request?.NgayHt?.ToString("dd/MM/yyyy")}",
                    QuyenSoId = quyenSoId,
                    SoPhieu = soPhieu,
                    NgayHT = request?.NgayHt,
                    NgayLap = request?.NgayLap,
                    NgoaiTeId = request?.NgoaiTeId,
                    TyGia = request?.TiGia,
                    TongTien = request?.TongTien,
                    TongTienVND = request?.TongTienVND,
                    IsSuaTien = false,
                    IsTaoTuDong = true,
                    IsPostSC = true,
                    PhieuXuatId = id,
                };
                //Tạo sổ cái
                var soCais = new List<SoCai>();
                foreach (var item in phieuThuCts)
                {
                    var soCai1 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                        MaGd = phieuThu.GiaoDichId,
                        NgayHt = phieuThu.NgayHT,
                        NgayLap = phieuThu.NgayLap,
                        SoCt = phieuThu.SoPhieu,
                        KhachHangId = phieuThu.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = phieuThu.GhiNoTkId,
                        TkDoiUng = item.GhiCoTk,
                        NgoaiTeId = phieuThu.NgoaiTeId,
                        TyGia = phieuThu.TyGia,
                        TyGiaHt = phieuThu.TyGia,
                        TyGiaHt2 = phieuThu.TyGia,
                        PhatSinhNo = 0,
                        PhatSinhCo = item.PsCo,
                        PhatSinhNoVND = 0,
                        PhatSinhCoVND = item.PsCoVND,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuThu.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.SoSeri,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuThu.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai1);
                    var soCai2 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                        MaGd = phieuThu.GiaoDichId,
                        NgayHt = phieuThu.NgayHT,
                        NgayLap = phieuThu.NgayLap,
                        SoCt = phieuThu.SoPhieu,
                        KhachHangId = phieuThu.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = item.GhiCoTk,
                        TkDoiUng = phieuThu.GhiNoTkId,
                        NgoaiTeId = phieuThu.NgoaiTeId,
                        TyGia = phieuThu.TyGia,
                        TyGiaHt = phieuThu.TyGia,
                        TyGiaHt2 = phieuThu.TyGia,
                        PhatSinhNo = item.PsCo,
                        PhatSinhCo = 0,
                        PhatSinhNoVND = item.PsCoVND,
                        PhatSinhCoVND = 0,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuThu.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.SoSeri,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuThu.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai2);
                }
                phieuThu.PhieuThuCTs = phieuThuCts;
                phieuThu.SoCais = soCais;
                await _context.PhieuThus.AddAsync(phieuThu);
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();//Làm mới dbContext để đảm bảo dữ liệu đc lấy cho lần sau là mới nhất
                if (quyenSoId != null && soPhieu != null)
                    await _quyenSoService.UpdateSoCTAsync(SystemConstants.LoaiPhieu.PhieuChi, quyenSoId, soPhieu);
                return new ApiResult() { IsSuccessed = true, Message = "Tạo phiếu thu thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }
        public async Task<ApiResult> TaoPhieuThuHD1Async(int? id, PhieuXuatRequest request)
        {
            try
            {
                //Xóa phiếu thu đã được tạo trước đó
                var firstPhieuThu = await _context.PhieuThus.FirstOrDefaultAsync(x => x.PhieuXuatId == id && !x.IsDeleted);
                if (firstPhieuThu != null)
                    await _phieuThuService.DeleteAsync(firstPhieuThu.Id);
                //Cách lấy diễn giải
                string? dienGiai = "";
                int cach = await _thamSoHeThongService.CachLayDienGiaiKhiTaoTuDongPhieuThuChiAsync(1);
                if (cach == 0)
                {
                    if (!string.IsNullOrEmpty(request?.SoHd) && request.NgayHt.HasValue)
                        dienGiai = "Thu tiền theo hóa đơn " + request.SoHd + " ngày " + request.NgayHt?.ToString("dd/MM/yyyy");
                    else
                        dienGiai = "Thu tiền bán hàng";
                }
                else if (cach == 1)
                {
                    var ct = request?.HoaDonBanHangRequests?.FirstOrDefault();
                    dienGiai = ct?.DienGiai ?? "Thu tiền bán hàng";
                }
                var phieuThuCts = new List<PhieuThuCT>();
                var tempPhieuThuCts = new List<PhieuThuCT>();
                var giaoDich = await _context.DMChungs.FirstOrDefaultAsync(x => x.LoaiDM == SystemConstants.DmChung.GiaoDichThu && x.DMChungUd == "2" && !x.IsDeleted);
                var quyenSo = await _context.QuyenSos.FirstOrDefaultAsync(x => x.MaCt == SystemConstants.LoaiPhieu.PhieuChi && x.IsUser == true && !x.IsDeleted);
                var taikhoan = await _context.TaiKhoans.FirstOrDefaultAsync(x => x.TaiKhoanUd == "1111" && !x.IsDeleted);
                string? quyenSoId = quyenSo?.SoQuyen;
                string? soPhieu = (quyenSo?.SoCtHienTai + 1).ToString();
                //Lấy các tài khoản thuộc 111
                if (!string.IsNullOrEmpty(request?.GhiNoTkUd) && request.GhiNoTkUd.Contains("111"))
                {
                    //Nhóm theo hóa đơn bán hàng
                    var hoaDonBanHangGrs = request.HoaDonBanHangRequests?.GroupBy(x => new { x.TkDoanhThu, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (hoaDonBanHangGrs != null)
                    {
                        foreach (var ct in hoaDonBanHangGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuThuCt = new PhieuThuCT()
                            {
                                GhiCoTk = item?.TkDoanhThu,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsCo = ct.Sum(x => x.Tien),
                                PsCoVND = ct.Sum(x => x.TienVND),
                                ThanhToan = ct.Sum(x => x.Tien),
                                ThanhToanVND = ct.Sum(x => x.TienVND),
                                ThanhToanQd = ct.Sum(x => x.TienVND),
                                TienHt = ct.Sum(x => x.TienVND),
                                DienGiai = dienGiai
                            };
                            tempPhieuThuCts.Add(phieuThuCt);
                        }
                    }
                    //Nhóm theo thuế
                    var tkThueGrs = request.HoaDonBanHangRequests?.GroupBy(x => new { x.TkThue }).ToList();
                    if (tkThueGrs != null)
                    {
                        foreach (var ct in tkThueGrs)
                        {
                            var item = ct.FirstOrDefault();// lấy ra item đại diện
                            var phieuThuCt = new PhieuThuCT()
                            {
                                GhiCoTk = item?.TkThue,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                PsCo = ct.Sum(x => x.Thue),
                                PsCoVND = ct.Sum(x => x.ThueVND),
                                ThanhToan = ct.Sum(x => x.Thue),
                                ThanhToanVND = ct.Sum(x => x.ThueVND),
                                ThanhToanQd = ct.Sum(x => x.ThueVND),
                                TienHt = ct.Sum(x => x.ThueVND),
                                DienGiai = dienGiai
                            };
                            tempPhieuThuCts.Add(phieuThuCt);
                        }
                    }
                    //Nhóm theo chiết khấu
                    if (request.IsSuaTienCk == true)
                    {
                        var phieuThuCt = new PhieuThuCT()
                        {
                            GhiCoTk = request.TkChietKhau,
                            PsCo = 0 - request.TienChietKhau,
                            PsCoVND = 0 - request.TienChietKhauVND,
                            ThanhToan = 0 - request.TienChietKhau,
                            ThanhToanVND = 0 - request.TienChietKhauVND,
                            ThanhToanQd = 0 - request.TienChietKhauVND,
                            TienHt = 0 - request.TienChietKhauVND,
                            DienGiai = dienGiai
                        };
                        tempPhieuThuCts.Add(phieuThuCt);
                    }
                }
                else if (!string.IsNullOrEmpty(request?.GhiNoTkUd) && request.GhiNoTkUd.Contains("131"))
                {
                    var phieuThuCt = new PhieuThuCT()
                    {
                        GhiCoTk = request.GhiNoTk,
                        PsCo = request.TongTien,
                        PsCoVND = request.TongTienVND,
                        ThanhToan = request.TongTien,
                        ThanhToanVND = request.TongTienVND,
                        ThanhToanQd = request.TongTienVND,
                        TienHt = request.TongTienVND,
                        DienGiai = dienGiai
                    };
                    tempPhieuThuCts.Add(phieuThuCt);
                }
                    //Lọc các phiếu chi ct trùng nhau và sau đó tính lại PsNo
                var phieuThuCtGrs = tempPhieuThuCts.GroupBy(x => new { x.GhiCoTk, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                foreach (var pt in phieuThuCtGrs)
                {
                    var item = pt.FirstOrDefault();// lấy ra item đại diện
                    var phieuThuCt = new PhieuThuCT()
                    {
                        GhiCoTk = item?.GhiCoTk,
                        VuViecId = item?.VuViecId,
                        MaPhiId = item?.MaPhiId,
                        MaTD01 = item?.MaTD01,
                        MaTD02 = item?.MaTD02,
                        MaTD03 = item?.MaTD03,
                        PsCo = pt.Sum(x => x.PsCo),
                        PsCoVND = pt.Sum(x => x.PsCoVND),
                        ThanhToan = pt.Sum(x => x.PsCo),
                        ThanhToanVND = pt.Sum(x => x.PsCoVND),
                        ThanhToanQd = pt.Sum(x => x.PsCoVND),
                        TienHt = pt.Sum(x => x.PsCoVND),
                        DienGiai = item?.DienGiai
                    };
                    phieuThuCts.Add(phieuThuCt);
                }
                //Nếu phiếu thu ct null thì không tạo
                if (phieuThuCts.Count == 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Tạo phiếu thu không thành công do không phải tài khoản 111 hoặc 131 !" };
                }
                //Tạo phiếu thu
                var phieuThu = new PhieuThu()
                {
                    LoaiPhieu = SystemConstants.LoaiPhieu.PhieuThu,
                    ChiNhanhId = request?.ChiNhanhId,
                    GiaoDichId = giaoDich?.Id,
                    KhachHangId = request?.KhachHangId,
                    DiaChi = request?.DiaChi,
                    MaSoThue = request?.MaSoThue,
                    GhiNoTkId = request?.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonMuaHang ? request?.GhiNoTk : taikhoan?.Id,
                    DienGiai = request?.DienGiai ?? $"Thu tiền theo hóa đơn {request?.SoHd} ngày {request?.NgayHt?.ToString("dd/MM/yyyy")}",
                    QuyenSoId = quyenSoId,
                    SoPhieu = soPhieu,
                    NgayHT = request?.NgayHt,
                    NgayLap = request?.NgayLap,
                    NgoaiTeId = request?.NgoaiTeId,
                    TyGia = request?.TiGia,
                    TongTien = request?.TongTien,
                    TongTienVND = request?.TongTienVND,
                    IsSuaTien = false,
                    IsTaoTuDong = true,
                    IsPostSC = true,
                    PhieuXuatId = id,
                };
                //Tạo sổ cái
                var soCais = new List<SoCai>();
                foreach (var item in phieuThuCts)
                {
                    var soCai1 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                        MaGd = phieuThu.GiaoDichId,
                        NgayHt = phieuThu.NgayHT,
                        NgayLap = phieuThu.NgayLap,
                        SoCt = phieuThu.SoPhieu,
                        KhachHangId = phieuThu.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = phieuThu.GhiNoTkId,
                        TkDoiUng = item.GhiCoTk,
                        NgoaiTeId = phieuThu.NgoaiTeId,
                        TyGia = phieuThu.TyGia,
                        TyGiaHt = phieuThu.TyGia,
                        TyGiaHt2 = phieuThu.TyGia,
                        PhatSinhNo = 0,
                        PhatSinhCo = item.PsCo,
                        PhatSinhNoVND = 0,
                        PhatSinhCoVND = item.PsCoVND,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuThu.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.SoSeri,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuThu.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai1);
                    var soCai2 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                        MaGd = phieuThu.GiaoDichId,
                        NgayHt = phieuThu.NgayHT,
                        NgayLap = phieuThu.NgayLap,
                        SoCt = phieuThu.SoPhieu,
                        KhachHangId = phieuThu.KhachHangId,
                        DienGiai = item.DienGiai,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                        Tk = item.GhiCoTk,
                        TkDoiUng = phieuThu.GhiNoTkId,
                        NgoaiTeId = phieuThu.NgoaiTeId,
                        TyGia = phieuThu.TyGia,
                        TyGiaHt = phieuThu.TyGia,
                        TyGiaHt2 = phieuThu.TyGia,
                        PhatSinhNo = item.PsCo,
                        PhatSinhCo = 0,
                        PhatSinhNoVND = item.PsCoVND,
                        PhatSinhCoVND = 0,
                        VuViecId = item.VuViecId,
                        MaPhiId = item.MaPhiId,
                        MaTD01 = item.MaTD01,
                        MaTD02 = item.MaTD02,
                        MaTD03 = item.MaTD03,
                        ChiNhanhId = phieuThu.ChiNhanhId,
                        SoHd = item.SoHd,
                        SoSeri = item.SoSeri,
                        NgayHd = item.NgayHd,
                        SoQuyen = phieuThu.QuyenSoId,
                        DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                    };
                    soCais.Add(soCai2);
                }
                phieuThu.PhieuThuCTs = phieuThuCts;
                phieuThu.SoCais = soCais;
                await _context.PhieuThus.AddAsync(phieuThu);
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();//Làm mới dbContext để đảm bảo dữ liệu đc lấy cho lần sau là mới nhất
                if (quyenSoId != null && soPhieu != null)
                    await _quyenSoService.UpdateSoCTAsync(SystemConstants.LoaiPhieu.PhieuChi, quyenSoId, soPhieu);
                return new ApiResult() { IsSuccessed = true, Message = "Tạo phiếu chi thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }
    }
}
