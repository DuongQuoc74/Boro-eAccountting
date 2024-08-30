using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.ThamSoHeThong;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuChiService : ApplicationService, IPhieuChiService
    {
        public readonly IRepository<PhieuChi, int?> _phieuChiRepository;
        public readonly IRepository<PhieuChiCT, int> _phieuChiCtRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGTGT;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly ACWebDbContext _context;
        public readonly IThamSoHeThongService _thamSoHeThongService;
        public PhieuChiService(IRepository<PhieuChi, int?> phieuChiRepository, IRepository<PhieuChiCT, int> phieuChiCtRepository, IRepository<HoaDonGtgt, int> hoaDonGTGT, IRepository<SoCai, int?> soCaiRepository
            , IRepository<TaiKhoan, int?> taiKhoanRepository, ACWebDbContext context, IThamSoHeThongService thamSoHeThongService)
        {
            _phieuChiRepository = phieuChiRepository;
            _phieuChiCtRepository = phieuChiCtRepository;
            _hoaDonGTGT = hoaDonGTGT;
            _soCaiRepository = soCaiRepository;
            _taiKhoanRepository = taiKhoanRepository;
            _context = context;
            _thamSoHeThongService = thamSoHeThongService;
        }
        public async Task<ApiResult> CreateAsync(PhieuChiRequest request)
        {
            try
            {
                // Return nếu chi tiết bằng null
                if (request.PhieuChiCTRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                if (request.HoaDonRequests != null)
                {
                    var invalidHoaDon = request.HoaDonRequests.Find(item =>
                        string.IsNullOrEmpty(item.SoCt0) ||
                        !item.NgayCt0.HasValue ||
                        !item.KhachHangId.HasValue);

                    if (invalidHoaDon != null)
                    {

                        if (string.IsNullOrEmpty(invalidHoaDon.SoCt0))
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Số hóa đơn trong Hóa đơn GTGT!" };
                        if (!invalidHoaDon.NgayCt0.HasValue)
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Ngày hóa đơn trong Hóa đơn GTGT!" };
                        if (!invalidHoaDon.KhachHangId.HasValue)
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Mã khách hàng trong Hóa đơn GTGT!" };

                    }
                }
                var tempPhieuThu = this.XuLyUpdateOrCreate(request);
                var phieuChi = ObjectMapper.Map<PhieuChiRequest, PhieuChi>(request);
                phieuChi.PhieuChiCTs = tempPhieuThu.PhieuChiCTs;
                phieuChi.HoaDonGTGTs = tempPhieuThu.HoaDonGTGTs;
                phieuChi.SoCais = tempPhieuThu.SoCais;
                var result = await _phieuChiRepository.InsertAsync(phieuChi, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }

        }
        private PhieuChi XuLyUpdateOrCreate(PhieuChiRequest request)
        {
            var phieuChi = new PhieuChi();
            try
            {
                var phieuChiCTs = new List<PhieuChiCT>();
                if (request.PhieuChiCTRequests != null)
                {
                    phieuChiCTs = ObjectMapper.Map<List<PhieuChiCTRequest>, List<PhieuChiCT>>(request.PhieuChiCTRequests);
                }
                var soCais = request.PhieuChiCTRequests?.SelectMany(item => new List<SoCai>()
                    {
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = item.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk = request.GhiNoTkId,
                            TkDoiUng = item.GhiNoTk,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNo = 0,
                            PhatSinhCo = item.PsNo,
                            PhatSinhNoVND = 0,
                            PhatSinhCoVND = item.PsNoVND,
                            VuViecId = item.VuViecId,
                            MaPhiId = item.MaPhiId,
                            MaTD01 = item.MaTD01,
                            MaTD02 = item.MaTD02,
                            MaTD03 = item.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = item.SoHd,
                            SoSeri = item.KiHieuMauHD,
                            NgayHd = item.NgayHd,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                        },
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = item.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk = item.GhiNoTk,
                            TkDoiUng = request.GhiNoTkId,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNo = item.PsNo,
                            PhatSinhCo = 0,
                            PhatSinhNoVND = item.PsNoVND,
                            PhatSinhCoVND = 0,
                            VuViecId = item.VuViecId,
                            MaPhiId = item.MaPhiId,
                            MaTD01 = item.MaTD01,
                            MaTD02 = item.MaTD02,
                            MaTD03 = item.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = item.SoHd,
                            SoSeri = item.KiHieuMauHD,
                            NgayHd = item.NgayHd,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                        }
                    }).ToList();
                var hoaDonGtgts = new List<HoaDonGtgt>();
                if (request.HoaDonRequests != null)
                {
                    hoaDonGtgts = ObjectMapper.Map<List<HoaDonRequest>, List<HoaDonGtgt>>(request.HoaDonRequests);
                    var soCaisThue = request.HoaDonRequests?.SelectMany(item => new List<SoCai>()
                    {
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = item.VatTu,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                            Tk = request.GhiNoTkId,
                            TkDoiUng = item.TkThue,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNo = 0,
                            PhatSinhCo = item.Thue,
                            PhatSinhNoVND = 0,
                            PhatSinhCoVND = item.ThueVND,
                            VuViecId = item.VuViecId,
                            MaPhiId = item.MaPhiId,
                            MaTD01 = item.MaTD01,
                            MaTD02 = item.MaTD02,
                            MaTD03 = item.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = item.SoCt0,
                            SoSeri = item.SoSeri0,
                            NgayHd = item.NgayCt0,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                        },
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuChi,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = item.VatTu,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.Thue,
                            Tk = item.TkThue,
                            TkDoiUng = request.GhiNoTkId,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNo = item.Thue,
                            PhatSinhCo = 0,
                            PhatSinhNoVND = item.ThueVND,
                            PhatSinhCoVND = 0,
                            VuViecId = item.VuViecId,
                            MaPhiId = item.MaPhiId,
                            MaTD01 = item.MaTD01,
                            MaTD02 = item.MaTD02,
                            MaTD03 = item.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = item.SoCt0,
                            SoSeri = item.SoSeri0,
                            NgayHd = item.NgayCt0,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = item.DieuChinhThueTNDNId
                        }
                    }).ToList();
                    soCais?.AddRange(soCaisThue ?? new List<SoCai>());
                }
                phieuChi.PhieuChiCTs = phieuChiCTs;
                phieuChi.HoaDonGTGTs = hoaDonGtgts;
                phieuChi.SoCais = soCais;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return phieuChi;
        }
        public async Task<ApiResult> DeleteAsync(int? id)
        {
            try
            {
                if(await _hoaDonGTGT.CountAsync(x=>x.PhieuChiId == id) > 0)
                    await _hoaDonGTGT.DeleteAsync(x => x.PhieuChiId == id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuChiId == id);
                await _phieuChiCtRepository.DeleteAsync(x => x.PhieuChiId == id);
                await _phieuChiRepository.DeleteAsync(id);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuChiId));
                await _phieuChiCtRepository.DeleteAsync(x => ids.Contains(x.PhieuChiId));
                await _phieuChiRepository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };

            }
        }
        public async Task<ApiResult> DeleteListSoPhuOldAsync(string bankAccountNumber)
        {
            try
            {

                var phieuChis = await _phieuChiRepository.GetListAsync(x => x.BankAccountNumber == bankAccountNumber);
                var phieuChiIds = phieuChis.Select(item => item.Id).ToList();
                await _soCaiRepository.DeleteAsync(x => phieuChiIds.Contains(x.PhieuChiId));
                await _phieuChiCtRepository.DeleteAsync(x => phieuChiIds.Contains(x.PhieuChiId));
                await _phieuChiRepository.DeleteManyAsync(phieuChiIds);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }


        public async Task<bool> DeletePhieuChiCTAsync(int id)
        {
            try
            {
                if (id == 0)
                    return false;
                await _phieuChiCtRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task<PhieuChiDto> GetByIdAsync(int? id)
        {
            try
            {
                var phieuChiQuery = from pc in _context.PhieuChis
                                    where pc.Id == id && !pc.IsDeleted
                                    join cn in _context.ChiNhanhs on pc.ChiNhanhId equals cn.Id
                                    join gd in _context.DMChungs on pc.GiaoDichId equals gd.Id
                                    join kh in _context.KhachHangs on pc.KhachHangId equals kh.Id into khs
                                    from kh in khs.DefaultIfEmpty()
                                    join tkc in _context.TaiKhoans on pc.GhiNoTkId equals tkc.Id
                                    join tkt in _context.TaiKhoans on pc.TkThue equals tkt.Id into tkts
                                    from tkt in tkts.DefaultIfEmpty()
                                    join nt in _context.NgoaiTes on pc.NgoaiTeId equals nt.Id
                                    select new { pc, cn, gd, kh, tkc, tkt, nt };
                var phieuChiCtsQuery = from pcct in _context.PhieuChiCTs
                                       where !pcct.IsDeleted && phieuChiQuery.Any(pc => pc.pc.Id == pcct.PhieuChiId)
                                       select new
                                       {
                                           pcct,
                                           common = (from tkn in _context.TaiKhoans
                                                     join nt in _context.NgoaiTes on pcct.NgoaiTeId equals nt.Id into nts
                                                     from nt in nts.DefaultIfEmpty()
                                                     join lt in _context.DMChungs on pcct.LoaiThue equals lt.Id into lts
                                                     from lt in lts.DefaultIfEmpty()
                                                     join mt in _context.ThueSuats on pcct.MaThue equals mt.Id into mts
                                                     from mt in mts.DefaultIfEmpty()
                                                     join kh in _context.KhachHangs on pcct.KhachHangId equals kh.Id into khs
                                                     from kh in khs.DefaultIfEmpty()
                                                     join vv in _context.VuViecs on pcct.VuViecId equals vv.Id into vvs
                                                     from vv in vvs.DefaultIfEmpty()
                                                     join mp in _context.DmMaPhis on pcct.MaPhiId equals mp.Id into mps
                                                     from mp in mps.DefaultIfEmpty()
                                                     where tkn.Id == pcct.GhiNoTk
                                                     select new { nt, tkn, lt, mt, kh, vv, mp }).FirstOrDefault()
                                       };
                var hoaDonGtgtsQuery = from hdgtgt in _context.HoaDonGTGTs
                                       where !hdgtgt.IsDeleted && phieuChiQuery.Any(pc => pc.pc.Id == hdgtgt.PhieuChiId)
                                       select new
                                       {
                                           hdgtgt,
                                           common = (from lt in _context.DMChungs
                                                     join kh in _context.KhachHangs on hdgtgt.KhachHangId equals kh.Id
                                                     join tkt in _context.TaiKhoans on hdgtgt.TkThue equals tkt.Id
                                                     join mt in _context.ThueSuats on hdgtgt.MaThue equals mt.Id into mts
                                                     from mt in mts.DefaultIfEmpty()
                                                     join vv in _context.VuViecs on hdgtgt.VuViecId equals vv.Id into vvs
                                                     from vv in vvs.DefaultIfEmpty()
                                                     join mp in _context.DmMaPhis on hdgtgt.MaPhiId equals mp.Id into mps
                                                     from mp in mps.DefaultIfEmpty()
                                                     where lt.Id == hdgtgt.LoaiThue
                                                     select new { lt, kh,tkt, mt, vv, mp }).FirstOrDefault()
                                       };
                var query = from pc in phieuChiQuery
                            select new
                            {
                                pc.pc,
                                pc.cn,
                                pc.gd,
                                pc.kh,
                                pc.tkc,
                                pc.tkt,
                                pc.nt,
                                PhieuChiCts =  phieuChiCtsQuery.ToList(),
                                HoaDonGTGTs =  hoaDonGtgtsQuery.ToList()
                            };
                var phieuChi = await query.ToListAsync();
                var item = phieuChi.Select(x => new PhieuChiDto()
                {
                    Id = x.pc.Id,
                    ChiNhanhId = x.pc.ChiNhanhId,
                    ChiNhanhUd = x.cn.ChiNhanhUd,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    GiaoDichId = x.pc.GiaoDichId,
                    GiaoDichUd = x.gd.DMChungUd,
                    GiaoDichNm = x.gd.DMChungNm,
                    KhachHangId = x.pc.KhachHangId,
                    KhachHangUd = x.kh?.KhachHangUd,
                    TenKhachHang = x.kh?.KhachHangNm,
                    DiaChi = x.pc.DiaChi,
                    MaSoThue = x.pc.MaSoThue,
                    SoDu = x.kh?.Sodu,
                    NguoiNhan = x.pc.NguoiNhan,
                    GhiNoTkId = x.pc.GhiNoTkId,
                    GhiNoTkUd = x.tkc.TaiKhoanUd,
                    GhiNoTkNm = x.tkc.TaiKhoanNm,
                    DienGiai = x.pc.DienGiai,
                    QuyenSoId = x.pc.QuyenSoId,
                    SoPhieu = x.pc.SoPhieu,
                    ChungTu = x.pc.ChungTu,
                    NgayLap = x.pc.NgayLap,
                    NgayHT = x.pc.NgayHT,
                    NgoaiTeId = x.pc.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TyGia = x.pc.TyGia,
                    HoaDonGTGT = x.pc.HoaDonGTGT,
                    TkThue = x.pc.TkThue,
                    TkThueUd = x.tkt?.TaiKhoanUd,
                    TongTienVND = x.pc.TongTienVND,
                    TongTien = x.pc.TongTien,
                    TienThue = x.pc.TienThue,
                    TienThueVND = x.pc.TienThueVND,
                    TienVND = x.pc.TienVND,
                    Tien = x.pc.Tien,
                    IsSuaTien = x.pc.IsSuaTien,
                    PhieuChiCTDtos =  x.PhieuChiCts.Select(y => new PhieuChiCTDto()
                    {
                        Stt = y.pcct.Id,
                        GhiNoTk = y.pcct.GhiNoTk,
                        GhiNoTkUd = y.common.tkn?.TaiKhoanUd,
                        GhiNoTkNm = y.common.tkn?.TaiKhoanNm,
                        PsNo = y.pcct.PsNo,
                        PsNoVND = y.pcct.PsNoVND,
                        DienGiai = y.pcct.DienGiai,
                        SoHd = y.pcct.SoHd,
                        NgayHd = y.pcct.NgayHd,
                        NgoaiTeId = y.pcct.NgoaiTeId,
                        NgoaiTeUd = y.common.nt?.NgoaiTeUd,
                        TienTrenHd = y.pcct.TienTrenHd,
                        TienTrenHdVND = y.pcct.TienTrenHdVND,
                        DaTt = y.pcct.DaTt,
                        DaTtVND = y.pcct.DaTtVND,
                        ConPhaiTt = y.pcct.ConPhaiTt,
                        ConPhaiTtVND = y.pcct.ConPhaiTtVND,
                        ThanhToan = y.pcct.ThanhToan,
                        ThanhToanVND = y.pcct.ThanhToanVND,
                        ThanhToanQd = y.pcct.ThanhToanQd,
                        KhachHangId = y.pcct.KhachHangId,
                        KhachHangUd = y.common.kh?.KhachHangUd,
                        KhachHangNm = y.common.kh?.KhachHangNm,
                        DiaChi = y.common.kh?.DiaChi,
                        MaSoThue = y.common.kh?.MaSoThue,
                        LoaiThue = y.pcct.LoaiThue,
                        LoaiThueUd = y.common.lt?.DMChungUd,
                        MaThue = y.pcct.MaThue,
                        MaThueUd = y.common.mt?.ThueSuatUd,
                        ThueSuat = y.pcct.ThueSuat,
                        Thue = y.pcct.Thue,
                        ThueVND = y.pcct.ThueVND,
                        SoCt = y.pcct.SoCt,
                        SoSeri = y.pcct.SoSeri,
                        KiHieuMauHD = y.pcct.KiHieuMauHD
                    }).ToList(),
                    HoaDonGTGTDtos = x.HoaDonGTGTs.Select(y => new HoaDonGtgtDto()
                    {
                        Stt = y.hdgtgt.Id,
                        LoaiThue = y.hdgtgt.LoaiThue,
                        LoaiThueUd = y.common.lt?.DMChungUd,
                        SoCt0 = y.hdgtgt.SoCt0,
                        SoCt = y.hdgtgt.SoCt0,
                        NgayCt = y.hdgtgt.NgayCt,
                        NgayCt0 = y.hdgtgt.NgayCt0,
                        KyHieuMauHD = y.hdgtgt.KyHieuMauHD,
                        SoSeri0 = y.hdgtgt.SoSeri0,
                        KhachHangId = y.hdgtgt.KhachHangId,
                        KhachHangUd = y.common.kh?.KhachHangUd,
                        KhachHangNm = y.common.kh?.KhachHangNm,
                        DiaChi = y.hdgtgt.DiaChi,
                        MaSoThue = y.hdgtgt.MaSoThue,
                        VatTu = y.hdgtgt.VatTu,
                        Tien = y.hdgtgt.Tien,
                        TienVND = y.hdgtgt.TienVND,
                        Thue = y.hdgtgt.Thue,
                        ThueVND = y.hdgtgt.ThueVND,
                        MaThue = y.hdgtgt.MaThue,
                        MaThueUd = y.common.mt?.ThueSuatUd,
                        ThueSuat = y.hdgtgt.ThueSuat,
                        TkThue = y.hdgtgt.TkThue,
                        TkThueUd = y.common.tkt?.TaiKhoanUd,
                        VuViecId = y.hdgtgt.VuViecId,
                        VuViecUd = y.common.vv?.VuViecUd,
                        GiaVND = y.hdgtgt.GiaVND,
                        Gia = y.hdgtgt.Gia,
                        SoLuong = y.hdgtgt.SoLuong,
                        MaPhiId = y.hdgtgt.MaPhiId,
                        MaCt = y.hdgtgt.MaCt
                    }).ToList()
                }).First();
                return item;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuChiDto();
            }

        }

        public async Task<int> GetCountByIdAsync(int? id)
        {
            return await _phieuChiRepository.CountAsync(x => x.Id == id);
        }

        public async Task<List<PhieuChiDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var query = from pc in _context.PhieuChis
                            where pc.LoaiPhieu == loaiPhieu && !pc.IsDeleted
                            join kh in _context.KhachHangs on pc.KhachHangId equals kh.Id into khs
                            from kh in khs.DefaultIfEmpty()
                            join tkc in _context.TaiKhoans on pc.GhiNoTkId equals tkc.Id
                            join nt in _context.NgoaiTes on pc.NgoaiTeId equals nt.Id
                            select new { pc, kh, tkc, nt };
                if (tuNgay.HasValue && denNgay.HasValue)
                    query = query.Where(x => x.pc.NgayHT >= tuNgay && x.pc.NgayHT <= denNgay);
                var items = await query.Select(x => new PhieuChiDto()
                {
                    Id = x.pc.Id,
                    KhachHangId = x.pc.KhachHangId,
                    KhachHangUd = x.kh.KhachHangUd,
                    TenKhachHang = x.kh.KhachHangNm,
                    DiaChi = x.pc.DiaChi,
                    MaSoThue = x.pc.MaSoThue,
                    SoDu = x.kh.Sodu,
                    GhiNoTkId = x.pc.GhiNoTkId,
                    GhiNoTkUd = x.tkc.TaiKhoanUd,
                    GhiNoTkNm = x.tkc.TaiKhoanNm,
                    DienGiai = x.pc.DienGiai,
                    NgayHT = x.pc.NgayHT,
                    NgayLap = x.pc.NgayLap,
                    SoPhieu = x.pc.SoPhieu,
                    NgoaiTeId = x.pc.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TyGia = x.pc.TyGia,
                    TongTienVND = x.pc.TongTienVND,
                    TongTien = x.pc.TongTien,
                }).ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuChiDto>();
            }

        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuChiDto> phieuChiDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuChiDtos != null)
            {
                foreach (var item in phieuChiDtos)
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
                SoLuongChungTu = phieuChiDtos != null ? phieuChiDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuChiRequest request)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => x.PhieuChiId == id);
                await _hoaDonGTGT.DeleteAsync(x => x.PhieuChiId == id);
                await _phieuChiCtRepository.DeleteAsync(x => x.PhieuChiId == id);
                // Return nếu chi tiết bằng null
                if (request.PhieuChiCTRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                if (request.HoaDonRequests != null)
                {
                    var invalidHoaDon = request.HoaDonRequests.Find(item =>
                        string.IsNullOrEmpty(item.SoCt0) ||
                        !item.NgayCt0.HasValue ||
                        !item.KhachHangId.HasValue);

                    if (invalidHoaDon != null)
                    {

                        if (string.IsNullOrEmpty(invalidHoaDon.SoCt0))
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Số hóa đơn trong Hóa đơn GTGT!" };
                        if (!invalidHoaDon.NgayCt0.HasValue)
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Ngày hóa đơn trong Hóa đơn GTGT!" };
                        if (!invalidHoaDon.KhachHangId.HasValue)
                            return new ApiResult() { IsSuccessed = false, Message = "Bạn chưa nhập Mã khách hàng trong Hóa đơn GTGT!" };

                    }
                }
                var tempPhieuChi = this.XuLyUpdateOrCreate(request);
                var phieuChi = ObjectMapper.Map(request, await _phieuChiRepository.GetAsync(id));
                phieuChi.HoaDonGTGTs = tempPhieuChi.HoaDonGTGTs;
                phieuChi.PhieuChiCTs = tempPhieuChi.PhieuChiCTs;
                phieuChi.SoCais = tempPhieuChi.SoCais;
                await _phieuChiRepository.UpdateAsync(phieuChi);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<GiaTriThamSoHeThongDto> GetGiaTriThamSoAsync()
        {
            var giaTri = new GiaTriThamSoHeThongDto();
            try
            {
                //Get tk thuế
                var thamSo1 = await _thamSoHeThongService.GetByThamSoHeThongUdAsync("TK_THUE_HDGTGT");
                string? tkThueUd = thamSo1.GiaTri?.Replace(" ", "");
                giaTri.TkThueUd = tkThueUd;
                var tk = await _context.TaiKhoans.Where(x => x.TaiKhoanUd == tkThueUd && !x.IsDeleted).FirstOrDefaultAsync();
                giaTri.TkThue = tk?.Id;
                //Get ký hiệu mẫu hóa đơn
                var thamSo2 = await _thamSoHeThongService.GetByThamSoHeThongUdAsync("KY_HIEU_HOA_DON");
                string? kyHieuMauHd = thamSo2.GiaTri?.Replace(" ", "");
                giaTri.KyHieuMauHD = kyHieuMauHd;
                //Get loại thuế
                var thamSo3 = await _thamSoHeThongService.GetByThamSoHeThongUdAsync("LOAI_THUE");
                string? loaiThueUd = thamSo3.GiaTri?.Replace(" ", "");
                giaTri.LoaiThueUd = loaiThueUd;
                var dmChung = await _context.DMChungs.Where(x => x.LoaiDM == SystemConstants.DmChung.LoaiThue && x.DMChungUd == loaiThueUd && !x.IsDeleted).FirstOrDefaultAsync();
                giaTri.LoaiThue = dmChung?.Id;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return giaTri;
        }
    }
}
