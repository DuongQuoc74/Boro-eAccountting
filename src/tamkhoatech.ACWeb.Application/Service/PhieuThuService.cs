using Microsoft.EntityFrameworkCore;
using Polly;
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

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuThuService : ApplicationService, IPhieuThuService
    {
        public readonly IRepository<PhieuThu, int?> _phieuThuRepository;
        public readonly IRepository<PhieuThuCT, int> _phieuThuCtRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly ACWebDbContext _context;
        public PhieuThuService(IRepository<PhieuThu, int?> phieuThuRepository, IRepository<PhieuThuCT, int> phieuThuCtRepository,
            IRepository<SoCai, int?> soCaiRepository, ACWebDbContext context)
        {
            _phieuThuRepository = phieuThuRepository;
            _phieuThuCtRepository = phieuThuCtRepository;
            _soCaiRepository = soCaiRepository;
            _context = context;
        }
        public async Task<ApiResult> CreateAsync(PhieuThuRequest request)
        {
            try
            {
                // Return nếu chi tiết bằng null
                if (request.PhieuThuCTRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                var tempPhieuThu = this.XuLyUpdateOrCreate(request);
                var phieuThu = ObjectMapper.Map<PhieuThuRequest, PhieuThu>(request);
                phieuThu.PhieuThuCTs = tempPhieuThu.PhieuThuCTs;
                phieuThu.SoCais = tempPhieuThu.SoCais;
                var result = await _phieuThuRepository.InsertAsync(phieuThu, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteAsync(int? id)
        {
            if (id == 0)
                return new ApiResult() { IsSuccessed = false, Message = "ID không hợp lệ !" };
            await _soCaiRepository.DeleteAsync(x => x.PhieuThuId == id);
            await _phieuThuCtRepository.DeleteAsync(x => x.PhieuThuId == id);
            await _phieuThuRepository.DeleteAsync(id);
            return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuThuId));
                await _phieuThuCtRepository.DeleteAsync(x => ids.Contains(x.PhieuThuId));
                await _phieuThuRepository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteListSoPhuOldAsync( string bankAccountNumber)
        {
            try
            {

                var phieuThus = await _phieuThuRepository.GetListAsync(x => x.BankAccountNumber == bankAccountNumber);
                var phieuThusIds = phieuThus.Select(item => item.Id).ToList();
                await _soCaiRepository.DeleteAsync(x => phieuThusIds.Contains(x.PhieuThuId));
                await _phieuThuCtRepository.DeleteAsync(x => phieuThusIds.Contains(x.PhieuThuId));
                await _phieuThuRepository.DeleteManyAsync(phieuThusIds);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<PhieuThuDto> GetByIdAsync(int? id)
        {
            try
            {
                var query = from pt in _context.PhieuThus
                            where pt.Id == id && !pt.IsDeleted
                            join cn in _context.ChiNhanhs on pt.ChiNhanhId equals cn.Id
                            join gd in _context.DMChungs on pt.GiaoDichId equals gd.Id
                            join kh in _context.KhachHangs on pt.KhachHangId equals kh.Id into khs
                            from kh in khs.DefaultIfEmpty()
                            join tkn in _context.TaiKhoans on pt.GhiNoTkId equals tkn.Id
                            join nt in _context.NgoaiTes on pt.NgoaiTeId equals nt.Id
                            join ptct in _context.PhieuThuCTs.Where(x => !x.IsDeleted) on pt.Id equals ptct.PhieuThuId into ptcts
                            select new
                            {
                                pt,
                                cn,
                                gd,
                                kh,
                                tkn,
                                nt,
                                PhieuThuCts = ptcts.Select(item => new
                                {
                                    item,
                                    common = (from tkc in _context.TaiKhoans 
                                                join nt in _context.NgoaiTes on item.NgoaiTeId equals nt.Id into nts
                                                from nt in nts.DefaultIfEmpty()
                                                join kh in _context.KhachHangs on item.KhachHangId equals kh.Id into khs
                                                from kh in khs.DefaultIfEmpty()
                                                join vv in _context.VuViecs on item.VuViecId equals vv.Id into vvs
                                                from vv in vvs.DefaultIfEmpty()
                                                join mp in _context.DmMaPhis on item.MaPhiId equals mp.Id into mps
                                                from mp in mps.DefaultIfEmpty()
                                                where tkc.Id == item.GhiCoTk
                                                select new { nt, tkc, kh, vv, mp }).FirstOrDefault()
                                }).ToList()
                            };
                var item = await query.Select(x => new PhieuThuDto
                {
                    Id = x.pt.Id,
                    ChiNhanhId = x.pt.ChiNhanhId,
                    ChiNhanhNm = x.cn.ChiNhanhNm,
                    GiaoDichId = x.pt.GiaoDichId,
                    GiaoDichUd = x.gd.DMChungUd,
                    GiaoDichNm = x.gd.DMChungNm,
                    KhachHangId = x.pt.KhachHangId,
                    KhachHangUd = x.kh.KhachHangUd,
                    KhachHangNm = x.kh.KhachHangNm,
                    DiaChi = x.pt.DiaChi,
                    MaSoThue = x.pt.MaSoThue,
                    SoDu = x.kh.Sodu,
                    GhiNoTkId = x.pt.GhiNoTkId,
                    GhiNoTkUd = x.tkn.TaiKhoanUd,
                    GhiNoTkNm = x.tkn.TaiKhoanNm,
                    DienGiai = x.pt.DienGiai,
                    QuyenSoId = x.pt.QuyenSoId,
                    NgayLap = x.pt.NgayLap,
                    NgayHT = x.pt.NgayHT,
                    SoPhieu = x.pt.SoPhieu,
                    NgoaiTeId = x.pt.NgoaiTeId,
                    NgoaiTeUd = x.nt.NgoaiTeUd,
                    TyGia = x.pt.TyGia,
                    TongTienVND =  x.pt.TongTienVND,
                    TongTien = x.pt.TongTien,
                    NguoiNop = x.pt.NguoiNop,
                    ChungTu = x.pt.ChungTu,
                    PhieuThuCTDtos = x.PhieuThuCts.Select(y=> new PhieuThuCTDto()
                    {
                        Stt = y.item.Id,
                        SoHd = y.item.SoHd,
                        NgayHd = y.item.NgayHd,
                        NgoaiTeId = y.item.NgoaiTeId,
                        NgoaiTeUd = y.common.nt.NgoaiTeUd,
                        GhiCoTk = y.item.GhiCoTk,
                        GhiCoTkUd = y.common.tkc.TaiKhoanUd,
                        GhiCoTkNm = y.common.tkc.TaiKhoanNm,
                        TienTrenHd = y.item.TienTrenHd,
                        DaTt = y.item.DaTt,
                        ConPhaiTt = y.item.ConPhaiTt,
                        PsCo = y.item.PsCo,
                        PsCoVND = y.item.PsCoVND,
                        ThanhToan = y.item.ThanhToan,
                        ThanhToanQd = y.item.ThanhToanQd,
                        ThanhToanVND = y.item.ThanhToanVND,
                        TienHt = y.item.TienHt,
                        TyGia = y.item.TyGia,
                        TyGiaGS = y.item.TyGiaGS,
                        BoPhanHTId = y.item.BoPhanHTId,
                        DieuChinhThueTNDNId = y.item.DieuChinhThueTNDNId,
                        GhiChuTD01 = y.item.GhiChuTD01,
                        GhiChuTD02 = y.item.GhiChuTD02,
                        GhiChuTD03 = y.item.GhiChuTD03,
                        HoaDonThuId = y.item.HoaDonThuId,
                        MaTD01 = y.item.MaTD01,
                        MaTD02 = y.item.MaTD02,
                        MaTD03 = y.item.MaTD03,
                        NgayTD01 = y.item.NgayTD01,
                        NgayTD02 = y.item.NgayTD02,
                        NgayLap = y.item.NgayLap,
                        NgayTD03 = y.item.NgayTD03,
                        VatTuId1 = y.item.VatTuId1,
                        HoaDonDichVuId = y.item.HoaDonDichVuId,
                        SoLuongTD01 = y.item.SoLuongTD01,
                        SoLuongTD02 = y.item.SoLuongTD02,
                        SoLuongTD03 = y.item.SoLuongTD03,
                        DienGiai = y.item.DienGiai,
                        DienGiai2 = y.item.DienGiai2,
                        SoCt = y.item.SoCt,
                        SoSeri = y.item.SoSeri,
                        KhachHangId = y.item.KhachHangId,
                        KhachHangUd = y.common.kh.KhachHangUd,
                        KhachHangNm = y.common.kh.KhachHangNm,
                        VuViecId = y.item.VuViecId,
                        MaPhiId = y.item.MaPhiId,
                    }).ToList()
                }).FirstAsync();
                return item;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PhieuThuDto();
            }
        }
        public async Task<int> GetCountByIdAsync(int? id)
        {
            return await _phieuThuRepository.CountAsync(x=>x.Id == id);
        }

        public async Task<List<PhieuThuDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay)
        {
            var items = await _phieuThuRepository.GetListAsync(x=>x.LoaiPhieu == loaiPhieu && x.NgayHT >= tuNgay && x.NgayHT <= denNgay);
            return ObjectMapper.Map<List<PhieuThu>, List<PhieuThuDto>>(items);
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuThuDto> phieuThuDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuThuDtos != null)
            {
                foreach (var item in phieuThuDtos)
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
                SoLuongChungTu = phieuThuDtos != null ? phieuThuDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuThuRequest request)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => x.PhieuThuId == id);
                await _phieuThuCtRepository.DeleteAsync(x => x.PhieuThuId == id);
                // Return nếu chi tiết bằng null
                if (request.PhieuThuCTRequests?.Count == 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Chưa nhập chi tiết!" };
                var tempPhieuThu = this.XuLyUpdateOrCreate(request);
                var phieuThu = ObjectMapper.Map(request, await _phieuThuRepository.GetAsync(id));
                phieuThu.PhieuThuCTs = tempPhieuThu.PhieuThuCTs;
                phieuThu.SoCais = tempPhieuThu.SoCais;
                await _phieuThuRepository.UpdateAsync(phieuThu);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }


        private PhieuThu XuLyUpdateOrCreate(PhieuThuRequest request)
        {
            var phieuThu = new PhieuThu();
            try
            {
                var phieuThuCTs = new List<PhieuThuCT>();
                if (request.PhieuThuCTRequests != null)
                {
                    phieuThuCTs = ObjectMapper.Map<List<PhieuThuCTRequest>, List<PhieuThuCT>>(request.PhieuThuCTRequests);
                }
                var soCais = request.PhieuThuCTRequests?.SelectMany(x => new List<SoCai>()
                    {
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = x.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk = request.GhiNoTkId,
                            TkDoiUng = x.GhiCoTk,
                            PhatSinhNo = x.PsCo,
                            PhatSinhCo = 0,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNoVND = x.PsCoVND,
                            PhatSinhCoVND = 0,
                            VuViecId = x.VuViecId,
                            MaPhiId = x.MaPhiId,
                            MaTD01 = x.MaTD01,
                            MaTD02 = x.MaTD02,
                            MaTD03 = x.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = x.SoHd,
                            NgayHd = x.NgayHd,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = x.DieuChinhThueTNDNId
                        },
                        new SoCai()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuThu,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoPhieu,
                            KhachHangId = request.KhachHangId,
                            DienGiai = x.DienGiai,
                            NhomDinhKhoan = SystemConstants.NhomDinhKhoan.DoanhThu,
                            Tk = x.GhiCoTk,
                            TkDoiUng = request.GhiNoTkId,
                            PhatSinhNo = 0,
                            PhatSinhCo = x.PsCo,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            TyGiaHt = request.TyGia,
                            TyGiaHt2 = request.TyGia,
                            PhatSinhNoVND = 0,
                            PhatSinhCoVND = x.PsCoVND,
                            VuViecId = x.VuViecId,
                            MaPhiId = x.MaPhiId,
                            MaTD01 = x.MaTD01,
                            MaTD02 = x.MaTD02,
                            MaTD03 = x.MaTD03,
                            ChiNhanhId = request.ChiNhanhId,
                            SoHd = x.SoHd,
                            NgayHd = x.NgayHd,
                            SoQuyen = request.QuyenSoId,
                            DieuChinhThueTNDNId = x.DieuChinhThueTNDNId
                        }
                    }).ToList();
                phieuThu.PhieuThuCTs = phieuThuCTs;
                phieuThu.SoCais = soCais;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return phieuThu;
        }
    }
}
