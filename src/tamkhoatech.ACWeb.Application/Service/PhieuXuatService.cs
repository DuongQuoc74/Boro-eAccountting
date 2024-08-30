using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static tamkhoatech.ACWeb.Constants.SystemConstants;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuXuatService : ApplicationService, IPhieuXuatService
    {
        public readonly IRepository<PhieuXuat, int?> _repository;
        public readonly IRepository<PhieuXuatCt, int> _phieuXuatCtRepository;
        public readonly IRepository<HoaDonBanHang, int> _hoaDonBanHangRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGtgtRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;
        public readonly IPhieuThuService _phieuThuService;
        public readonly ACWebDbContext _context;
        public PhieuXuatService(IRepository<PhieuXuat, int?> repository, ACWebDbContext context, IRepository<HoaDonBanHang, int> hoaDonBanHangRepository
            ,IRepository<SoCai, int?> soCaiRepository, IRepository<HoaDonGtgt, int> hoaDonGtgtRepository, IPhieuThuService phieuThuService, IRepository<PhieuXuatCt, int> phieuXuatCtRepository
            , IRepository<TheKho, int?> theKhoRepository)
        {
            _repository = repository;
            _context = context;
            _hoaDonBanHangRepository = hoaDonBanHangRepository;
            _soCaiRepository = soCaiRepository;
            _hoaDonGtgtRepository = hoaDonGtgtRepository;
            _phieuThuService = phieuThuService;
            _phieuXuatCtRepository = phieuXuatCtRepository;
            _theKhoRepository = theKhoRepository;
        }

        public async Task<List<PhieuXuatDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var query = from px in _context.PhieuXuats
                            join kh in _context.KhachHangs on px.KhachHangId equals kh.Id
                            join tk in _context.TaiKhoans on px.GhiNoTk equals tk.Id
                            join nt in _context.NgoaiTes on px.NgoaiTeId equals nt.Id
                            where px.LoaiPhieu == loaiPhieu && !px.IsDeleted
                            select new { px, kh, tk, nt };
                if (tuNgay.HasValue && denNgay.HasValue)
                    query = query.Where(x => x.px.NgayHt >= tuNgay && x.px.NgayHt <= denNgay);

                var items = await query.Select(x => new PhieuXuatDto()
                {
                    Id = x.px.Id,
                    NgayHt = x.px.NgayHt,
                    NgayLap = x.px.NgayLap,
                    SoCt = x.px.SoCt,
                    SoHd = x.px.SoHd,
                    KyHieuMauHD = x.px.KyHieuMauHD,                  
                    KhachHangId = x.px.KhachHangId,
                    KhachHangUd = x.kh.KhachHangUd,
                    KhachHangNm = x.kh.KhachHangNm,
                    DiaChi = x.px.DiaChi,
                    MaSoThue = x.px.MaSoThue, 
                    GhiNoTk = x.px.GhiNoTk,
                    GhiNoTkUd = x.tk.TaiKhoanUd,
                    GhiNoTkNm = x.tk.TaiKhoanNm,
                    TienHangVND = x.px.TienHangVND,
                    ThueVatVND = x.px.ThueVatVND,
                    TongTienVND = x.px.TongTienVND,
                    DienGiai = x.px.DienGiai,
                    NgoaiTeId = x.px.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TiGia = x.px.TiGia,
                    TienHang = x.px.TienHang,
                    ThueVat = x.px.ThueVat,
                    TongTien = x.px.TongTien,
                    HanTt = x.px.HanTt,
                    EInvoice = x.px.EInvoice,
                    IsHuy = x.px.IsHuy,
                }).ToListAsync();
                return items;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuXuatDto>();
            }
        }

        public async Task<List<PhieuXuatDto>> GetListByKhachHangIdAsync(int? khachHangId)
        {
            return ObjectMapper.Map<List<PhieuXuat>, List<PhieuXuatDto>>(await _repository.GetListAsync(x => x.KhachHangId == khachHangId));
        }
        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuXuatDto> phieuXuatDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuXuatDtos != null)
            {
                foreach (var item in phieuXuatDtos)
                {
                    if (item.TongTien == null)
                        item.TongTien = 0;
                    sumPhatSinh += item.TongTien;
                    if (item.TongTienVND == null)
                        item.TongTienVND = 0;
                    sumPhatSinhVND += item.TongTienVND;
                }
            }
            var result = new TongTienDto()
            {
                SoLuongChungTu = phieuXuatDtos != null ? phieuXuatDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }
        

        public async Task<PhieuXuatDto> GetHD1ByIdAsync(int? id)
        {
            try
            {
                var query = from px in _context.PhieuXuats
                            where px.Id == id && !px.IsDeleted
                            join cn in _context.ChiNhanhs on px.ChiNhanhId equals cn.Id
                            join kh in _context.KhachHangs on px.KhachHangId equals kh.Id
                            join tkn in _context.TaiKhoans on px.GhiNoTk equals tkn.Id
                            join nt in _context.NgoaiTes on px.NgoaiTeId equals nt.Id
                            join hdbh in _context.HoaDonBanHangs.Where(x => !x.IsDeleted) on px.Id equals hdbh.PhieuXuatId into hdbhs
                            select new { px, cn, kh, tkn, nt, 
                                HoaDonBanHangs =  hdbhs.Select( item => new
                                {
                                    item,
                                    common = (from tkdt in _context.TaiKhoans
                                              join mt in _context.ThueSuats on item.ThueSuatId equals mt.Id
                                              join tkt in _context.TaiKhoans on item.TkThue equals tkt.Id
                                              join ct in _context.CongTrinhs on item.CongTrinhId equals ct.Id into cts
                                              from ct in cts.DefaultIfEmpty()
                                              join vv in _context.VuViecs on item.VuViecId equals vv.Id into vvs
                                              from vv in vvs.DefaultIfEmpty()
                                              join mp in _context.DmMaPhis on item.MaPhiId equals mp.Id into mps
                                              from mp in mps.DefaultIfEmpty()
                                              where tkdt.Id == item.TkDoanhThu
                                              select new { tkdt, mt, tkt, ct, vv, mp }).FirstOrDefault()
                                }).ToList()
                            };

                var item = await query.Select(x => new PhieuXuatDto
                {
                    Id = x.px.Id,
                    ChiNhanhId = x.px.ChiNhanhId,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    KhachHangId = x.px.KhachHangId,
                    KhachHangUd = x.kh.KhachHangUd,
                    KhachHangNm = x.kh.KhachHangNm,
                    DiaChi = x.px.DiaChi,
                    MaSoThue = x.px.MaSoThue,
                    SoDu = x.kh.Sodu,
                    NguoiMuaHang = x.px.NguoiMuaHang,
                    QuyenSo = x.px.QuyenSo,
                    SoCt = x.px.SoCt,
                    NgayHt = x.px.NgayHt,
                    NgayLap = x.px.NgayLap,
                    HinhThucTt = x.px.HinhThucTt,
                    GhiChu = x.px.GhiChu,
                    GhiNoTk = x.px.GhiNoTk,
                    GhiNoTkUd = x.tkn.TaiKhoanUd,
                    GhiNoTkNm = x.tkn.TaiKhoanNm,
                    DienGiai = x.px.DienGiai,
                    KyHieuMauHD = x.px.KyHieuMauHD,
                    SoHd = x.px.SoHd,
                    SoSeri = x.px.SoSeri,
                    NhomHang = x.px.NhomHang,
                    NgoaiTeId = x.px.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TiGia = x.px.TiGia,
                    IsSuaTien = x.px.IsSuaTien,
                    IsSuaTienCk = x.px.IsSuaTienCk,
                    IsSuaTienSauThue = x.px.IsSuaTienSauThue,
                    IsSuaTienThue = x.px.IsSuaTienThue,
                    IsSuaTkThue = x.px.IsSuaTkThue,
                    TkThueVat = x.px.TkThueVat,
                    TkChietKhau = x.px. TkChietKhau,
                    TkThueVatDu = x.px.TkThueVatDu,
                    TienHangVND = x.px.TienHangVND,
                    TienHang = x.px.TienHang,
                    ThueVat = x.px.ThueVat,
                    ThueVatVND = x.px.ThueVatVND,
                    TienChietKhauVND = x.px.TienChietKhauVND,
                    TienChietKhau = x.px.TienChietKhau,
                    TongTien = x.px.TongTien,
                    TongTienVND = x.px.TongTienVND,
                    HoaDonBanHangDtos = x.HoaDonBanHangs.Select(y => new HoaDonBanHangDto
                    {
                        Id = y.item.Id,
                        Stt = y.item.Id,
                        TkDoanhThu = y.item.TkDoanhThu,
                        TkDoanhThuUd = y.common.tkdt.TaiKhoanUd,
                        TkDoanhThuNm = y.common.tkdt.TaiKhoanNm,
                        DonViTinh = y.item.DonViTinh,
                        SoLuong = y.item.SoLuong,
                        Gia = y.item.Gia,
                        GiaVND = y.item.GiaVND,
                        Tien = y.item.Tien,
                        TienVND = y.item.TienVND,
                        ThueSuatId = y.item.ThueSuatId,
                        ThueSuatUd = y.common.mt.ThueSuatUd,
                        ThueSuat = y.item.ThueSuat,
                        Thue = y.item.Thue,
                        ThueVND = y.item.ThueVND,
                        TkThue = y.item.TkThue,
                        TkThueUd = y.common.tkt.TaiKhoanUd,
                        DienGiai = y.item.DienGiai,
                        CongTrinhId = y.item.CongTrinhId,
                        CongTrinhUd = y.common.ct.CongTrinhUd,
                        VuViecId = y.item.VuViecId,
                        VuViecUd = y.common.vv.VuViecUd,
                        MaPhiId = y.item.MaPhiId,                      
                        MaPhiUd = y.common.mp.DmMaPhiUd                      
                    }).ToList(),
                }).FirstAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuXuatDto();
            }
        }
        public async Task<PhieuXuatDto> GetHDAByIdAsync(int? id)
        {
            try
            {
                var query = from px in _context.PhieuXuats
                            where px.Id == id && !px.IsDeleted
                            join cn in _context.ChiNhanhs on px.ChiNhanhId equals cn.Id
                            join kh in _context.KhachHangs on px.KhachHangId equals kh.Id
                            join tkn in _context.TaiKhoans on px.GhiNoTk equals tkn.Id
                            join bp in _context.BoPhans on px.BoPhanId equals bp.Id
                            join mt in _context.ThueSuats on px.ThueSuatId equals mt.Id
                            join nt in _context.NgoaiTes on px.NgoaiTeId equals nt.Id
                            join pxct in _context.PhieuXuatCts.Where(x => !x.IsDeleted) on px.Id equals pxct.PhieuXuatId into pxcts
                            select new
                            {
                                px,
                                cn,
                                kh,
                                tkn,
                                bp,
                                nt,
                                mt,
                                PhieuXuatCts = pxcts.Select(item => new
                                {
                                    item,
                                    common = (from vt in _context.VatTus
                                              join k in _context.Khos on item.KhoId equals k.Id
                                              join mt in _context.ThueSuats on item.ThueSuatId equals mt.Id
                                              join tkck in _context.TaiKhoans on item.TkChietKhau equals tkck.Id
                                              join tkt in _context.TaiKhoans on item.TkThue equals tkt.Id
                                              join tkdt in _context.TaiKhoans on item.TkDoanhThu equals tkdt.Id
                                              join tkk in _context.TaiKhoans on item.TkKho equals tkk.Id
                                              join tkgv in _context.TaiKhoans on item.TkGiaVon equals tkgv.Id
                                              join ct in _context.CongTrinhs on item.CongTrinhId equals ct.Id into cts
                                              from ct in cts.DefaultIfEmpty()
                                              join vv in _context.VuViecs on item.VuViecId equals vv.Id into vvs
                                              from vv in vvs.DefaultIfEmpty()
                                              join mp in _context.DmMaPhis on item.MaPhiId equals mp.Id into mps
                                              from mp in mps.DefaultIfEmpty()
                                              where vt.Id == item.VatTuId
                                              select new { vt, k, tkck, mt, tkt, tkdt, tkk,tkgv, ct, vv, mp }).FirstOrDefault()
                                }).ToList()
                            };

                var item = await query.Select(x => new PhieuXuatDto
                {
                    Id = x.px.Id,
                    ChiNhanhId = x.px.ChiNhanhId,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    KhachHangId = x.px.KhachHangId,
                    KhachHangUd = x.kh.KhachHangUd,
                    KhachHangNm = x.kh.KhachHangNm,
                    DiaChi = x.px.DiaChi,
                    MaSoThue = x.px.MaSoThue,
                    SoDu = x.kh.Sodu,
                    NguoiMuaHang = x.px.NguoiMuaHang,
                    QuyenSo = x.px.QuyenSo,
                    SoCt = x.px.SoCt,
                    NgayHt = x.px.NgayHt,
                    NgayLap = x.px.NgayLap,
                    HinhThucTt = x.px.HinhThucTt,
                    GhiChu = x.px.GhiChu,
                    GhiNoTk = x.px.GhiNoTk,
                    GhiNoTkUd = x.tkn.TaiKhoanUd,
                    GhiNoTkNm = x.tkn.TaiKhoanNm,
                    DienGiai = x.px.DienGiai,
                    KyHieuMauHD = x.px.KyHieuMauHD,
                    SoHd = x.px.SoHd,
                    SoSeri = x.px.SoSeri,
                    NhomHang = x.px.NhomHang,
                    NgoaiTeId = x.px.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TiGia = x.px.TiGia,
                    IsSuaTien = x.px.IsSuaTien,
                    IsSuaTienCk = x.px.IsSuaTienCk,
                    IsSuaTienSauThue = x.px.IsSuaTienSauThue,
                    IsSuaTienThue = x.px.IsSuaTienThue,
                    IsSuaTkThue = x.px.IsSuaTkThue,
                    TkThueVat = x.px.TkThueVat,
                    TkChietKhau = x.px.TkChietKhau,
                    TkThueVatDu = x.px.TkThueVatDu,
                    TienHangVND = x.px.TienHangVND,
                    TienHang = x.px.TienHang,
                    ThueVat = x.px.ThueVat,
                    ThueVatVND = x.px.ThueVatVND,
                    TienChietKhauVND = x.px.TienChietKhauVND,
                    TienChietKhau = x.px.TienChietKhau,
                    TongTien = x.px.TongTien,
                    TongTienVND = x.px.TongTienVND,
                    BoPhanId = x.px.BoPhanId,
                    BoPhanNm = x.bp.BoPhanNm,
                    SoLuong = x.px.SoLuong,
                    TienVon = x.px.TienVon,
                    TienVonVND = x.px.TienVonVND,
                    ThueSuatId = x.px.ThueSuatId,
                    ThueSuatUd = x.mt.ThueSuatUd,
                    ThueSuat = x.px.ThueSuat,
                    TienHangCk = x.px.TienHangCk,
                    TienHangCkVND = x.px.TienHangCkVND,
                    PhieuXuatCtDtos = x.PhieuXuatCts.Select(y => new PhieuXuatCtDto ()
                    {
                        Id = y.item.Id,
                        Stt = y.item.Id,
                        VatTuId = y.item.VatTuId,
                        VatTuUd = y.common.vt.VatTuUd,
                        VatTuNm = y.common.vt.VatTuNm,
                        DonViTinh = y.common.vt.DonViTinh,
                        KhoId = y.item.KhoId,
                        KhoUd = y.common.k.KhoUd,
                        SoLuong = y.item.SoLuong,
                        Gia = y.item.Gia,
                        GiaVND = y.item.GiaVND,
                        Tien = y.item.Tien,
                        TienVND = y.item.TienVND,
                        TyLeCk = y.item.TyLeCk,
                        TienCk = y.item.TienCk,
                        TienCkVND = y.item.TienCkVND,
                        TkChietKhau = y.item.TkChietKhau,
                        TkChietKhauUd = y.common.tkck.TaiKhoanUd,
                        ThueSuatId = y.item.ThueSuatId,
                        ThueSuatUd = y.common.mt.ThueSuatUd,
                        ThueSuat = y.item.ThueSuat,
                        Thue = y.item.Thue,
                        ThueVND = y.item.ThueVND,
                        TienSauThue = y.item.TienSauThue,
                        TienSauThueVND = y.item.TienSauThueVND,
                        TkThue = y.item.TkThue,
                        TkThueUd = y.common.tkck.TaiKhoanUd,
                        TkDoanhThu = y.item.TkDoanhThu,
                        TkKho = y.item.TkKho,
                        TkKhoUd = y.common.tkk.TaiKhoanUd,
                        TkGiaVon = y.item.TkGiaVon,
                        TkGiaVonUd = y.common.tkgv.TaiKhoanUd,
                        GiaVon = y.item.GiaVon,
                        GiaVonVND = y.item.GiaVonVND,
                        TienVon = y.item.TienVon,
                        TienVonVND = y.item.TienVonVND,
                        CongTrinhId = y.item.CongTrinhId,
                        CongTrinhUd = y.common.ct.CongTrinhUd,
                        VuViecId = y.item.VuViecId,
                        VuViecUd = y.common.vv.VuViecUd,
                        MaPhiId = y.item.MaPhiId,
                        MaPhiUd = y.common.mp.DmMaPhiUd
                    }).ToList(),
                }).FirstAsync();
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuXuatDto();
            }
        }

        public async Task<ApiResult> DeleteAsync(int? id)
        {
            try
            {

                var phieuThu = await _context.PhieuThus.FirstOrDefaultAsync(x => x.PhieuXuatId == id && !x.IsDeleted);
                if (phieuThu != null)
                    await _phieuThuService.DeleteAsync(phieuThu.Id);
                var phieuXuatCts = await _phieuXuatCtRepository.GetListAsync(x => x.PhieuXuatId == id);
                foreach (var item in phieuXuatCts)
                {
                    await _theKhoRepository.DeleteAsync(x=>x.PhieuXuatCtId == item.Id);
                }
                await _phieuXuatCtRepository.DeleteAsync(x =>x.PhieuXuatId == id);
                await _hoaDonBanHangRepository.DeleteAsync(x =>x.PhieuXuatId == id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuXuatId == id);
                await _hoaDonGtgtRepository.DeleteAsync(x => x.PhieuXuatId == id);
                await _repository.DeleteAsync(id);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }
        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {

                var phieuThuIds = await _context.PhieuThus.Where(x => ids.Contains(x.PhieuXuatId) && !x.IsDeleted).Select(x => x.Id).ToListAsync();
                if (phieuThuIds != null)
                    await _phieuThuService.DeleteListAsync(phieuThuIds);
                foreach (var id in ids)
                {
                    var phieuXuatCts = await _phieuXuatCtRepository.GetListAsync(x => x.PhieuXuatId == id);
                    foreach (var item in phieuXuatCts)
                    {
                        await _theKhoRepository.DeleteAsync(x => x.PhieuXuatCtId == item.Id);
                    }
                }
                await _phieuXuatCtRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatId));
                await _hoaDonBanHangRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatId));
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatId));
                await _hoaDonGtgtRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }
        public async Task<ApiResult> CreateAsync(PhieuXuatRequest request)
        {
            try
            {
                // Return nếu chi tiết bằng null
                if (request.PhieuXuatCtRequests?.Count == 0 && request.HoaDonBanHangRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                var tempPhieuXuat = this.XuLyUpdateOrCreate(request);
                var phieuXuat = ObjectMapper.Map<PhieuXuatRequest, PhieuXuat>(request);
                phieuXuat.PhieuXuatCts = tempPhieuXuat.PhieuXuatCts;
                phieuXuat.HoaDonBanHangs = tempPhieuXuat.HoaDonBanHangs;
                phieuXuat.HoaDonGtgts = tempPhieuXuat.HoaDonGtgts;
                phieuXuat.SoCais = tempPhieuXuat.SoCais;
                var result = await _repository.InsertAsync(phieuXuat, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> UpdateAsync(int? id, PhieuXuatRequest request)
        {
            try
            {
                var phieuThu = await _context.PhieuThus.FirstOrDefaultAsync(x => x.PhieuXuatId == id && !x.IsDeleted);
                if (phieuThu != null)
                    await _phieuThuService.DeleteAsync(phieuThu.Id);
                var phieuXuatCts = await _phieuXuatCtRepository.GetListAsync(x => x.PhieuXuatId == id);
                foreach (var item in phieuXuatCts)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuXuatCtId == item.Id);
                }
                await _phieuXuatCtRepository.DeleteAsync(x => x.PhieuXuatId == id);
                await _hoaDonBanHangRepository.DeleteAsync(x => x.PhieuXuatId == id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuXuatId == id);
                await _hoaDonGtgtRepository.DeleteAsync(x => x.PhieuXuatId == id);
                // Return nếu chi tiết bằng null
                if (request.PhieuXuatCtRequests?.Count == 0 && request.HoaDonBanHangRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                var tempPhieuXuat = this.XuLyUpdateOrCreate(request);
                var phieuXuat = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuXuat.PhieuXuatCts = tempPhieuXuat.PhieuXuatCts;
                phieuXuat.HoaDonBanHangs = tempPhieuXuat.HoaDonBanHangs;
                phieuXuat.HoaDonGtgts = tempPhieuXuat.HoaDonGtgts;
                phieuXuat.SoCais = tempPhieuXuat.SoCais;
                await _repository.UpdateAsync(phieuXuat);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        private PhieuXuat XuLyUpdateOrCreate(PhieuXuatRequest request)
        {
            var phieuXuat = new PhieuXuat();
            try
            {
                var hoaDonGtgts = new List<HoaDonGtgt>();
                var phieuXuatCts = new List<PhieuXuatCt>();
                var hoaDonBanHangs = new List<HoaDonBanHang>();
                var soCais = new List<SoCai>();
                if (request.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonDichVu)
                {
                    hoaDonBanHangs = ObjectMapper.Map<List<HoaDonBanHangRequest>, List<HoaDonBanHang>>(request.HoaDonBanHangRequests ?? new List<HoaDonBanHangRequest>());
                    // Thêm vào sổ cái (Doanh thu)
                    soCais = request.HoaDonBanHangRequests?.SelectMany(x => new List<SoCai>()
                    {
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            DienGiai = x.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk  = request.TkThueVatDu,
                            TkDoiUng = x.TkDoanhThu,
                            PhatSinhNo = x.Tien,
                            PhatSinhCo = 0,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TiGia,
                            PhatSinhNoVND = x.TienVND,
                            PhatSinhCoVND = 0,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = request.SoHd,
                            SoSeri = request.SoSeri,
                            NgayHd = request.NgayHt,
                            SoQuyen = request.QuyenSo,
                            BoPhanHTId = x.BoPhanHTId,
                            DieuChinhThueTNDNId = x.DieuChinhThueTNDNId,
                        },
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            DienGiai = x.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk  = x.TkDoanhThu,
                            TkDoiUng = request.TkThueVatDu,
                            PhatSinhNo = 0,
                            PhatSinhCo = x.Tien,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TiGia,
                            PhatSinhNoVND = 0,
                            PhatSinhCoVND = x.TienVND,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = request.SoHd,
                            SoSeri = request.SoSeri,
                            NgayHd = request.NgayHt,
                            SoQuyen = request.QuyenSo,
                            BoPhanHTId = x.BoPhanHTId,
                            DieuChinhThueTNDNId = x.DieuChinhThueTNDNId,
                        }
                    }).ToList();
                    //Thêm vào sổ cái (Chiết khấu)
                    if (request.TienChietKhau != 0)
                    {
                        var scChietKhau1 = new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.ChietKhau,
                            Tk = request.TkThueVatDu,
                            TkDoiUng = request.TkChietKhau,
                            PhatSinhNo = 0,
                            PhatSinhCo = request.TienChietKhau,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TiGia,
                            PhatSinhNoVND = 0,
                            PhatSinhCoVND = request.TienChietKhauVND,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = request.SoHd,
                            SoSeri = request.SoSeri,
                            NgayHd = request.NgayHt,
                            SoQuyen = request.QuyenSo,
                        };
                        var scChietKhau2 = new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.ChietKhau,
                            Tk = request.TkChietKhau,
                            TkDoiUng = request.TkThueVatDu,
                            PhatSinhNo = request.TienChietKhau,
                            PhatSinhCo = 0,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TiGia,
                            PhatSinhNoVND = request.TienChietKhauVND,
                            PhatSinhCoVND = 0,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = request.SoHd,
                            SoSeri = request.SoSeri,
                            NgayHd = request.NgayHt,
                            SoQuyen = request.QuyenSo,
                        };
                        soCais?.AddRange(new[] { scChietKhau1, scChietKhau2 });
                    }
                    //Thêm vào sổ cái (Thuế)
                    var groupBySoCais = request.HoaDonBanHangRequests?.GroupBy(x => new { x.TkThue, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupBySoCais != null)
                    {
                        foreach (var t in groupBySoCais)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện
                            var soCai1 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                                DienGiai = item?.DienGiai,
                                Tk = request.TkThueVatDu,
                                TkDoiUng = item?.TkThue,
                                PhatSinhNo = t.Sum(x => x.Thue),
                                PhatSinhCo = 0,
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = t.Sum(x => x.ThueVND),
                                PhatSinhCoVND = 0,
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            var soCai2 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonDichVu,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                                DienGiai = item?.DienGiai,
                                Tk = item?.TkThue,
                                TkDoiUng = request.TkThueVatDu,
                                PhatSinhNo = 0,
                                PhatSinhCo = t.Sum(x => x.Thue),
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = 0,
                                PhatSinhCoVND = t.Sum(x => x.ThueVND),
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            soCais?.AddRange(new[] { soCai1, soCai2 });
                        }
                    }
                    // Thêm vào hóa đơn GTGT
                    var groupByHoaDonGtgts = request.HoaDonBanHangRequests?.GroupBy(x => new { x.ThueSuatId, x.TkThue, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupByHoaDonGtgts != null)
                    {
                        foreach (var t in groupByHoaDonGtgts)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện                   
                            var hoaDonGtgt = new HoaDonGtgt()
                            {
                                ChiNhanhId = request.ChiNhanhId,
                                MauBC = SystemConstants.MauBC,
                                MaCt = SystemConstants.LoaiPhieu.HoaDonDichVu,
                                NgayCt = request.NgayHt,
                                NgayCt0 = request.NgayHt,
                                SoCt = request.SoCt,
                                SoCt0 = request.SoHd,
                                SoSeri0 = request.SoSeri,
                                KyHieuMauHD = request.KyHieuMauHD,
                                KhachHangId = request.KhachHangId,
                                KhachHangUd = request.KhachHangUd,
                                KhachHangNm = request.KhachHangNm,
                                DiaChi = request.DiaChi,
                                MaSoThue = request.MaSoThue,
                                VatTu = item?.DienGiai,
                                Tien = t.Sum(x => x.Tien),
                                TienVND = t.Sum(x => x.TienVND),
                                Thue = t.Sum(x => x.Thue),
                                ThueVND = t.Sum(x => x.ThueVND),
                                MaThue = item?.ThueSuatId,
                                ThueSuat = item?.ThueSuat,
                                TkThue = item?.TkThue,
                                TkDu = request.TkThueVatDu,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                VuViecId = item?.VuViecId,
                                DieuChinhThueTNDNId = item?.DieuChinhThueTNDNId,
                            };
                            hoaDonGtgts.Add(hoaDonGtgt);
                        }
                    }
                }
                else if (request.LoaiPhieu == SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho)
                {
                    phieuXuatCts = ObjectMapper.Map<List<PhieuXuatCtRequest>, List<PhieuXuatCt>>(request.PhieuXuatCtRequests ?? new List<PhieuXuatCtRequest>());
                    //Thêm vào thẻ kho
                    foreach (var item in phieuXuatCts)
                    {
                        var theKho = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            SoSeri = request.SoSeri,
                            SoDh = request.SoHd,
                            KhachHangId = request.KhachHangId,
                            KhoId = item.KhoId,
                            DienGiai = request.DienGiai,
                            BoPhanId = request.BoPhanId,
                            GhiNoCoTk = request.GhiNoTk,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TiGia,
                            VatTuId = item.VatTuId,
                            TkVatTu = item.TkKho,
                            TkDoanThu = item.TkDoanhThu,
                            TkGiaVon = item.TkGiaVon,
                            SoLuongXuat = item.SoLuong,
                            Gia = item.GiaVon,
                            GiaVND = item.GiaVonVND,
                            TienXuat = item.TienVon,
                            TienXuatVND = item.TienVonVND,
                            Gia2 = item.Gia,
                            GiaVND2 = item.GiaVND,
                            Tien2 = item.Tien,
                            TienVND2 = item.TienVND,
                            HanTt = request.HanTt,
                            ThueSuat = item.ThueSuat,
                            Thue = item.Thue,
                            ThueVND = item.ThueVND,
                            TkThueNo = request.TkThueVat,
                            TkThueCo = request.TkThueVatDu,
                            ChietKhau = item.TienCk,
                            ChietKhauVND = item.TienCkVND,
                            TkChietKhau = item.TkChietKhau,
                            ChiNhanhId = request.ChiNhanhId,
                            MaPhiId = item.MaPhiId,
                            MaTD01 = item.MaTD01,
                            MaTD02 = item.MaTD02,
                            MaTD03 = item.MaTD03,
                            VuViecId = item.VuViecId,
                            DieuChinhThueTNDNId = item.DieuChinhThueTNDNId,
                        };
                        item.TheKho = theKho;
                    }
                    // Thêm vào hóa đơn GTGT
                    var groupByHoaDonGtgts = request.PhieuXuatCtRequests?.GroupBy(x => new { x.ThueSuatId, x.TkThue, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupByHoaDonGtgts != null)
                    {
                        foreach (var t in groupByHoaDonGtgts)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện                   
                            var hoaDonGtgt = new HoaDonGtgt()
                            {
                                ChiNhanhId = request.ChiNhanhId,
                                MauBC = SystemConstants.MauBC,
                                MaCt = SystemConstants.LoaiPhieu.HoaDonDichVu,
                                NgayCt = request.NgayHt,
                                NgayCt0 = request.NgayHt,
                                SoCt = request.SoCt,
                                SoCt0 = request.SoHd,
                                SoSeri0 = request.SoSeri,
                                KyHieuMauHD = request.KyHieuMauHD,
                                KhachHangId = request.KhachHangId,
                                KhachHangUd = request.KhachHangUd,
                                KhachHangNm = request.KhachHangNm,
                                DiaChi = request.DiaChi,
                                MaSoThue = request.MaSoThue,
                                VatTu = request.DienGiai,
                                Tien = t.Sum(x => x.Tien),
                                TienVND = t.Sum(x => x.TienVND),
                                Thue = t.Sum(x => x.Thue),
                                ThueVND = t.Sum(x => x.ThueVND),
                                MaThue = item?.ThueSuatId,
                                ThueSuat = item?.ThueSuat,
                                TkThue = item?.TkThue,
                                TkDu = request.TkThueVatDu,
                                GhiChu = request.GhiChu,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                VuViecId = item?.VuViecId,
                                DieuChinhThueTNDNId = item?.DieuChinhThueTNDNId,
                            };
                            hoaDonGtgts.Add(hoaDonGtgt);
                        }
                    }
                    //Thêm vào sổ cái (Doanh thu)
                    var groupByTkDoanThuSoCais = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkDoanhThu, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupByTkDoanThuSoCais != null)
                    {
                        foreach (var t in groupByTkDoanThuSoCais)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện
                            var soCai1 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                                DienGiai = request.DienGiai,
                                Tk = request.GhiNoTk,
                                TkDoiUng = item?.TkDoanhThu,
                                PhatSinhNo = t.Sum(x => x.Tien),
                                PhatSinhCo = 0,
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = t.Sum(x => x.TienVND),
                                PhatSinhCoVND = 0,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            var soCai2 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                                DienGiai = request.DienGiai,
                                Tk = item?.TkThue,
                                TkDoiUng = request.TkThueVatDu,
                                PhatSinhNo = 0,
                                PhatSinhCo = t.Sum(x => x.Thue),
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = 0,
                                PhatSinhCoVND = t.Sum(x => x.ThueVND),
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            soCais?.AddRange(new[] { soCai1, soCai2 });
                        }
                    }
                    //Thêm vào sổ cái (VON)
                    var groupByTkVonThuSoCais = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkGiaVon, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupByTkVonThuSoCais != null)
                    {
                        foreach (var t in groupByTkVonThuSoCais)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện
                            var soCai1 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Von,
                                DienGiai = request.DienGiai,
                                Tk = item?.TkGiaVon,
                                TkDoiUng = item?.TkKho,
                                PhatSinhNo = t.Sum(x => x.TienVon),
                                PhatSinhCo = 0,
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = t.Sum(x => x.TienVonVND),
                                PhatSinhCoVND = 0,
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            var soCai2 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Von,
                                DienGiai = request.DienGiai,
                                Tk = item?.TkKho,
                                TkDoiUng = item?.TkGiaVon,
                                PhatSinhNo = 0,
                                PhatSinhCo = t.Sum(x => x.TienVon),
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = 0,
                                PhatSinhCoVND = t.Sum(x => x.TienVonVND),
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            soCais?.AddRange(new[] { soCai1, soCai2 });
                        }
                    }
                    //Thêm vào sổ cái (VON)
                    var groupByTkChietKhauSoCais = request.PhieuXuatCtRequests?.GroupBy(x => new { x.TkChietKhau, x.VuViecId, x.MaPhiId, x.MaTD01, x.MaTD02, x.MaTD03 }).ToList();
                    if (groupByTkChietKhauSoCais != null)
                    {
                        foreach (var t in groupByTkChietKhauSoCais)
                        {
                            var item = t.FirstOrDefault();// lấy ra item đại diện
                            var soCai1 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.ChietKhau,
                                DienGiai = request.DienGiai,
                                Tk = request.GhiNoTk,
                                TkDoiUng = item?.TkChietKhau,
                                PhatSinhNo = 0,
                                PhatSinhCo = t.Sum(x => x.TienCk),
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = 0,
                                PhatSinhCoVND = t.Sum(x => x.TienCkVND),
                                VuViecId = item?.VuViecId,
                                MaPhiId = item?.MaPhiId,
                                MaTD01 = item?.MaTD01,
                                MaTD02 = item?.MaTD02,
                                MaTD03 = item?.MaTD03,
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            var soCai2 = new SoCai()
                            {
                                MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                                NgayHt = request.NgayHt,
                                NgayLap = request.NgayLap,
                                SoCt = request.SoCt,
                                KhachHangId = request.KhachHangId,
                                NhomDinhKhoan = SystemConstants.NhomDinhKhoan.ChietKhau,
                                DienGiai = request.DienGiai,
                                Tk = item?.TkChietKhau,
                                TkDoiUng = request.GhiNoTk,
                                PhatSinhNo = t.Sum(x => x.TienCk),
                                PhatSinhCo = 0,
                                NgoaiTeId = request.NgoaiTeId,
                                TyGia = request.TiGia,
                                PhatSinhNoVND = t.Sum(x => x.TienCk),
                                PhatSinhCoVND = 0,
                                ChiNhanhId = request.ChiNhanhId,
                                SoHd = request.SoHd,
                                SoSeri = request.SoSeri,
                                NgayHd = request.NgayHt,
                                SoQuyen = request.QuyenSo,
                            };
                            soCais?.AddRange(new[] { soCai1, soCai2 });
                        }
                    }
                    //Thêm vào sổ cái (Thue)
                    var scChietKhau1 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                        NgayHt = request.NgayHt,
                        NgayLap = request.NgayLap,
                        SoCt = request.SoCt,
                        KhachHangId = request.KhachHangId,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                        Tk = request.TkThueVatDu,
                        TkDoiUng = request.TkThueVat,
                        PhatSinhNo = 0,
                        PhatSinhCo = request.ThueVat,
                        NgoaiTeId = request.NgoaiTeId,
                        TyGia = request.TiGia,
                        PhatSinhNoVND = 0,
                        PhatSinhCoVND = request.ThueVatVND,
                        ChiNhanhId = request.ChiNhanhId,
                        SoHd = request.SoHd,
                        SoSeri = request.SoSeri,
                        NgayHd = request.NgayHt,
                        SoQuyen = request.QuyenSo,
                    };
                    var scChietKhau2 = new SoCai()
                    {
                        MaNk = SystemConstants.LoaiPhieu.HoaDonBanHangKiemPhieuXuatKho,
                        NgayHt = request.NgayHt,
                        NgayLap = request.NgayLap,
                        SoCt = request.SoCt,
                        KhachHangId = request.KhachHangId,
                        NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                        Tk = request.TkThueVat,
                        TkDoiUng = request.TkThueVatDu,
                        PhatSinhNo = request.ThueVat,
                        PhatSinhCo = 0,
                        NgoaiTeId = request.NgoaiTeId,
                        TyGia = request.TiGia,
                        PhatSinhNoVND = request.ThueVatVND,
                        PhatSinhCoVND = 0,
                        ChiNhanhId = request.ChiNhanhId,
                        SoHd = request.SoHd,
                        SoSeri = request.SoSeri,
                        NgayHd = request.NgayHt,
                        SoQuyen = request.QuyenSo,
                    };
                    soCais?.AddRange(new[] { scChietKhau1, scChietKhau2 });
                }
                phieuXuat.PhieuXuatCts = phieuXuatCts;
                phieuXuat.HoaDonBanHangs = hoaDonBanHangs;
                phieuXuat.HoaDonGtgts = hoaDonGtgts;
                phieuXuat.SoCais = soCais;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return phieuXuat;
        }
    }
}
