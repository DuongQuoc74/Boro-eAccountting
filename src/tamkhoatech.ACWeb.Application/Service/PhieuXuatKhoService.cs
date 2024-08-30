using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.EntityFrameworkCore;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuXuatKhoService : ApplicationService, IPhieuXuatKhoService
    {
        public readonly IRepository<PhieuXuatKho, int?> _repository;
        public readonly IRepository<PhieuXuatKhoCt, int> _phieuXuatKhoCtRepository;
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<KhachHang, int?> _khachHangRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGTGT;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly IRepository<DMChung, int?> _dmChungRepository;
        public readonly IRepository<VatTu, int?> _vatTuRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;

        public PhieuXuatKhoService(IRepository<PhieuXuatKho, int?> repository, IRepository<NgoaiTe, int?> ngoaiTeRepository, 
            IRepository<PhieuXuatKhoCt, int> PhieuXuatKhoCtRepository, IRepository<KhachHang, int?> khachHangRepository,
            IRepository<HoaDonGtgt, int> hoaDonGTGT, IRepository<SoCai, int?> soCaiRepository , IRepository<TaiKhoan, int?> taiKhoanRepository, IRepository<DMChung, int?> dmChungRepository
            , IRepository<VatTu, int?> vatTuRepository, IRepository<Kho, int?> khoRepository , IRepository<TheKho, int?> theKhoRepository)
        {
            _repository = repository;
            _ngoaiTeRepository = ngoaiTeRepository;
            _phieuXuatKhoCtRepository = PhieuXuatKhoCtRepository;
            _khachHangRepository = khachHangRepository;
            _hoaDonGTGT = hoaDonGTGT;
            _soCaiRepository = soCaiRepository;
            _taiKhoanRepository = taiKhoanRepository;
            _dmChungRepository = dmChungRepository;
            _vatTuRepository = vatTuRepository;
            _khoRepository = khoRepository;
            _theKhoRepository = theKhoRepository;
        }

        public async Task<ApiResult> CreateAsync(PhieuXuatKhoRequest request)
        {
            try
            {
                var phieuXuatKhoCts = new List<PhieuXuatKhoCt>();
                if (request.PhieuXuatKhoCtRequests != null)
                {
                    request.PhieuXuatKhoCtRequests.ForEach(item => item.Id = 0);
                    phieuXuatKhoCts = ObjectMapper.Map<List<PhieuXuatKhoCtRequest>, List<PhieuXuatKhoCt>>(request.PhieuXuatKhoCtRequests);                    
                    foreach (var item in phieuXuatKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekho = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatKho,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            KhoId = item.KhoId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiCoTk,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            SoLuongXuat = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienXuat = item.Tien,
                            TienXuatVND = item.TienVND,
                        };
                        theKhos.Add(thekho);
                        item.TheKhos = theKhos;
                    }
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuXuatKho = ObjectMapper.Map<PhieuXuatKhoRequest, PhieuXuatKho>(request);
                phieuXuatKho.PhieuXuatKhoCts = phieuXuatKhoCts;
                phieuXuatKho.SoCais = soCais;
               var result = await _repository.InsertAsync(phieuXuatKho, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống, vui lòng liên hệ bộ phân kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteAsync(int? id)
        {
            try
            {
                var ct = await _phieuXuatKhoCtRepository.GetListAsync(x => x.PhieuXuatKhoId == id);
                foreach (var item in ct)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuXuatKhoCtId == item.Id);
                }
                await _soCaiRepository.DeleteAsync(x => x.PhieuXuatKhoId == id);
                await _phieuXuatKhoCtRepository.DeleteAsync(x => x.PhieuXuatKhoId == id);
                await _repository.DeleteAsync(id);
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
                foreach (var id in ids)
                {
                    var ct =  await _phieuXuatKhoCtRepository.GetListAsync(x=> x.PhieuXuatKhoId == id);
                    foreach (var item in ct)
                    {
                        await _theKhoRepository.DeleteAsync(x=>x.PhieuXuatKhoCtId == item.Id);
                    }
                }
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatKhoId));
                await _phieuXuatKhoCtRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatKhoId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<PhieuXuatKhoDto> GetByIdAsync(int? id)
        {
            try
            {
                var phieuXuatKho = await _repository.GetAsync(id);
                var phieuXuatKhoCts = await _phieuXuatKhoCtRepository.GetListAsync(x => x.PhieuXuatKhoId == id);
                var phieuXuatKhoCtDtos = ObjectMapper.Map<List<PhieuXuatKhoCt>, List<PhieuXuatKhoCtDto>>(phieuXuatKhoCts);
                if (phieuXuatKhoCtDtos != null && phieuXuatKhoCtDtos.Count > 0)
                {
                    foreach (var item in phieuXuatKhoCtDtos)
                    {
                        var vt = await _vatTuRepository.FirstOrDefaultAsync(x=>x.Id == item.VatTuId);
                        var kho = await _khoRepository.FirstOrDefaultAsync(x => x.Id == item.KhoId);
                        var tkNo = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiNoTk);
                        var tkCo = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiCoTk);
                        item.VatTuUd = vt?.VatTuUd;
                        item.VatTuNm = vt?.VatTuNm;
                        item.DonViTinh = vt?.DonViTinh;
                        item.KhoUd = kho?.KhoUd;
                        item.GhiNoTkUd = tkNo?.TaiKhoanUd;
                        item.GhiCoTkUd = tkCo?.TaiKhoanUd;

                    }
                }
                var phieuXuatKhoDto = ObjectMapper.Map<PhieuXuatKho, PhieuXuatKhoDto>(phieuXuatKho);
                phieuXuatKhoDto.PhieuXuatKhoCtDtos = phieuXuatKhoCtDtos;
                return phieuXuatKhoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuXuatKhoDto();
            }
        }

        public async Task<int> GetCountByIdAsync(int? id)
        {
            return await _repository.CountAsync(x => x.Id == id);
        }
        public async Task<List<PhieuXuatKhoDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay)
        {

            try
            {              
                var result = await _repository.GetListAsync(x => x.NgayHt >= tuNgay && x.NgayHt <= denNgay);
                var phieuXks = ObjectMapper.Map<List<PhieuXuatKho>, List<PhieuXuatKhoDto>>(result);
                foreach (var item in phieuXks)
                {
                    if (item.NgoaiTeId != 0 || item.NgoaiTeId != null)
                    {
                        var nt = await _ngoaiTeRepository.FirstOrDefaultAsync(x => x.Id == item.NgoaiTeId);
                        item.NgoaiTeUd = nt?.NgoaiTeUd;
                    }
                    else
                        item.NgoaiTeUd = SystemConstants.NA;

                    if (item.KhachHangId != 0 || item.KhachHangId != null)
                    {
                        var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id == item.KhachHangId);
                        item.KhachHangUd = kh?.KhachHangUd;
                        item.KhachHangNm = kh?.KhachHangNm;
                    }
                    else
                        item.KhachHangUd = SystemConstants.NA;

                    if (item.GiaoDichId != 0 || item.GiaoDichId != null)
                    {
                        var gd = await _dmChungRepository.FirstOrDefaultAsync(x => x.Id == item.GiaoDichId);
                        item.GiaoDichUd = gd?.DMChungUd;
                    }
                    else
                        item.GiaoDichUd = SystemConstants.NA;

                }
                return phieuXks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuXuatKhoDto>();
            }
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuXuatKhoDto> phieuXuatKhoDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuXuatKhoDtos != null)
            {
                foreach (var item in phieuXuatKhoDtos)
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
                SoLuongChungTu = phieuXuatKhoDtos != null ? phieuXuatKhoDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuXuatKhoRequest request)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => x.PhieuXuatKhoId == id);
                var ct = await _phieuXuatKhoCtRepository.GetListAsync(x => x.PhieuXuatKhoId == id);
                foreach (var item in ct)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuXuatKhoCtId == item.Id);
                }
                await _phieuXuatKhoCtRepository.DeleteAsync(x => x.PhieuXuatKhoId == id);

                var phieuXuatKhoCts = new List<PhieuXuatKhoCt>();
                if (request.PhieuXuatKhoCtRequests != null)
                {
                    request.PhieuXuatKhoCtRequests.ForEach(item => item.Id = 0);
                    phieuXuatKhoCts = ObjectMapper.Map<List<PhieuXuatKhoCtRequest>, List<PhieuXuatKhoCt>>(request.PhieuXuatKhoCtRequests);
                    foreach (var item in phieuXuatKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekho = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatKho,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            KhoId = item.KhoId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiCoTk,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            SoLuongXuat = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienXuat = item.Tien,
                            TienXuatVND = item.TienVND,
                        };
                        theKhos.Add(thekho);
                        item.TheKhos = theKhos;
                    }
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }

                var phieuXuatKho = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuXuatKho.PhieuXuatKhoCts = phieuXuatKhoCts;
                phieuXuatKho.SoCais = soCais;
                await _repository.UpdateAsync(phieuXuatKho);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống, vui lòng liên hệ bộ phân kỹ thuật để được hỗ trợ." };
            }
        }
    }
}
