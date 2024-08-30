using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuXuatDcKhoService : ApplicationService, IPhieuXuatDcKhoService
    {
        public readonly IRepository<PhieuXuatDcKho, int?> _repository;
        public readonly IRepository<PhieuXuatDcKhoCt, int> _phieuXuatDcKhoCtRepository;
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<SoCai, int?> _soCairepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGTGT;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly IRepository<DMChung, int?> _dmChungRepository;
        public readonly IRepository<VatTu, int?> _vatTuRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;
        public readonly IRepository<DmMaPhi, int?> _dmMaPhiRepository;
        public PhieuXuatDcKhoService(IRepository<PhieuXuatDcKho, int?> repository, IRepository<NgoaiTe, int?> ngoaiTeRepository, 
            IRepository<PhieuXuatDcKhoCt, int> PhieuXuatDcKhoCtRepository,
            IRepository<HoaDonGtgt, int> hoaDonGTGT, IRepository<SoCai, int?> soCairepository , IRepository<TaiKhoan, int?> taiKhoanRepository, IRepository<DMChung, int?> dmChungRepository
            , IRepository<VatTu, int?> vatTuRepository, IRepository<Kho, int?> khoRepository , IRepository<TheKho, int?> theKhoRepository, IRepository<DmMaPhi, int?> dmMaPhiRepository)
        {
            _repository = repository;
            _ngoaiTeRepository = ngoaiTeRepository;
            _phieuXuatDcKhoCtRepository = PhieuXuatDcKhoCtRepository;
            _hoaDonGTGT = hoaDonGTGT;
            _soCairepository = soCairepository;
            _taiKhoanRepository = taiKhoanRepository;
            _dmChungRepository = dmChungRepository;
            _vatTuRepository = vatTuRepository;
            _khoRepository = khoRepository;
            _theKhoRepository = theKhoRepository;
            _dmMaPhiRepository = dmMaPhiRepository;
        }

        public async Task<ApiResult> CreateAsync(PhieuXuatDcKhoRequest request)
        {
            try
            {
                var phieuXuatDcKhoCts = new List<PhieuXuatDcKhoCt>();
                if (request.PhieuXuatDcKhoCtRequests != null)
                { 
                    request.PhieuXuatDcKhoCtRequests.ForEach(item => item.Id = 0);
                    phieuXuatDcKhoCts = ObjectMapper.Map<List<PhieuXuatDcKhoCtRequest>, List<PhieuXuatDcKhoCt>>(request.PhieuXuatDcKhoCtRequests);
                    foreach (var item in phieuXuatDcKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekhoNhap = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatDcKho,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = request.KhoNhapId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiCoTK,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            TkVatTu = item.GhiNoTK,
                            SoLuongNhap = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienNhap = item.Tien,
                            TienNhapVND = item.TienVND,
                        };
                        theKhos.Add(thekhoNhap);

                        var thekhoXuat = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatDcKho,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = request.KhoNhapId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiNoTK,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            TkVatTu = item.GhiCoTK,
                            SoLuongXuat = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienXuat = item.Tien,
                            TienXuatVND = item.TienVND,
                        };
                        theKhos.Add(thekhoXuat);
                        item.TheKhos = theKhos;
                    }
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuXuatDcKho = ObjectMapper.Map<PhieuXuatDcKhoRequest, PhieuXuatDcKho>(request);
                phieuXuatDcKho.PhieuXuatDcKhoCts = phieuXuatDcKhoCts;
                phieuXuatDcKho.SoCais = soCais;
                var rusult = await _repository.InsertAsync(phieuXuatDcKho, true);
                return new ApiResult() { IsSuccessed = true, Id=rusult.Id, Message = "Thêm mới thành công !" };
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
                var ct = await _phieuXuatDcKhoCtRepository.GetListAsync(x => x.PhieuXuatDcKhoId == id);
                foreach (var item in ct)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuXuatDcKhoCtId == item.Id);
                }
                await _soCairepository.DeleteAsync(x => x.PhieuXuatDcKhoId == id);
                await _phieuXuatDcKhoCtRepository.DeleteAsync(x => x.PhieuXuatDcKhoId == id);
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
                    var ct = await _phieuXuatDcKhoCtRepository.GetListAsync(x => x.PhieuXuatDcKhoId == id);
                    foreach (var item in ct)
                    {
                        await _theKhoRepository.DeleteAsync(x => x.PhieuXuatDcKhoCtId == item.Id);
                    }
                }
                await _soCairepository.DeleteAsync(x => ids.Contains(x.PhieuXuatDcKhoId));
                await _phieuXuatDcKhoCtRepository.DeleteAsync(x => ids.Contains(x.PhieuXuatDcKhoId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<PhieuXuatDcKhoDto> GetByIdAsync(int? id)
        {
            try
            {
                var phieuXuatDcKho = await _repository.GetAsync(id);
                var phieuXuatDcKhoCts = await _phieuXuatDcKhoCtRepository.GetListAsync(x => x.PhieuXuatDcKhoId == id);
                var phieuXuatDcKhoCtDtos = ObjectMapper.Map<List<PhieuXuatDcKhoCt>, List<PhieuXuatDcKhoCtDto>>(phieuXuatDcKhoCts);
                if (phieuXuatDcKhoCtDtos != null && phieuXuatDcKhoCtDtos.Count > 0)
                {
                    foreach (var item in phieuXuatDcKhoCtDtos)
                    {
                        var vt = await _vatTuRepository.GetAsync(item.VatTuId);
                        var tkNo = await _taiKhoanRepository.GetAsync(item.GhiNoTK);
                        var tkCo = await _taiKhoanRepository.GetAsync(item.GhiCoTK);
                        item.VatTuUd = vt.VatTuUd;
                        item.VatTuNm = vt.VatTuNm;
                        item.DonViTinh = vt.DonViTinh;
                        item.GhiNoTKUd = tkNo.TaiKhoanUd;
                        item.GhiCoTKUd = tkCo.TaiKhoanUd;
                        if (item.MaPhiId.HasValue)
                        {
                            var maPhi = await _dmMaPhiRepository.GetAsync(item.MaPhiId);
                            item.MaPhiUd = maPhi.DmMaPhiUd;
                        }
                    }
                }
                var phieuXuatDcKhoDto = ObjectMapper.Map<PhieuXuatDcKho, PhieuXuatDcKhoDto>(phieuXuatDcKho);
                phieuXuatDcKhoDto.PhieuXuatDcKhoCtDtos = phieuXuatDcKhoCtDtos;
                return phieuXuatDcKhoDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuXuatDcKhoDto();
            }
        }

        public Task<int> GetCountByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PhieuXuatDcKhoDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var phieuXuatDcKhos = ObjectMapper.Map<List<PhieuXuatDcKho>, List<PhieuXuatDcKhoDto>>(await _repository.GetListAsync(x=>x.NgayHt>=tuNgay && x.NgayHt<=denNgay));
                foreach (var item in phieuXuatDcKhos)
                {
                    if (item.NgoaiTeId != 0 || item.NgoaiTeId != null)
                    {
                        var nt = await _ngoaiTeRepository.GetAsync(x => x.Id == item.NgoaiTeId);
                        item.NgoaiTeUd = nt.NgoaiTeUd;
                    }
                    else
                        item.NgoaiTeUd = SystemConstants.NA;

                    if (item.KhoNhapId != 0 || item.KhoNhapId != null)
                    {
                        var kho = await _khoRepository.GetAsync(x => x.Id == item.KhoNhapId);
                        item.KhoNhapUd = kho.KhoUd;
                    }
                    else
                        item.KhoNhapUd = SystemConstants.NA;


                    if (item.KhoXuatId != 0 || item.KhoXuatId != null)
                    {
                        var kho = await _khoRepository.GetAsync(x => x.Id == item.KhoXuatId);
                        item.KhoXuatUd = kho.KhoUd;
                    }
                    else
                        item.KhoXuatUd = SystemConstants.NA;

                }
                return phieuXuatDcKhos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuXuatDcKhoDto>();
            }
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuXuatDcKhoDto> phieuXuatDcKhoDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuXuatDcKhoDtos != null)
            {
                foreach (var item in phieuXuatDcKhoDtos)
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
                SoLuongChungTu = phieuXuatDcKhoDtos != null ? phieuXuatDcKhoDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuXuatDcKhoRequest request)
        {
            try
            {
                await _soCairepository.DeleteAsync(x => x.PhieuXuatDcKhoId == id);
                var ct = await _phieuXuatDcKhoCtRepository.GetListAsync(x => x.PhieuXuatDcKhoId == id);
                foreach (var item in ct)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuXuatDcKhoCtId == item.Id);
                }
                await _phieuXuatDcKhoCtRepository.DeleteAsync(x => x.PhieuXuatDcKhoId == id);

                var phieuXuatDcKhoCts = new List<PhieuXuatDcKhoCt>();
                if (request.PhieuXuatDcKhoCtRequests != null)
                {
                    request.PhieuXuatDcKhoCtRequests.ForEach(item => item.Id = 0);
                    phieuXuatDcKhoCts = ObjectMapper.Map<List<PhieuXuatDcKhoCtRequest>, List<PhieuXuatDcKhoCt>>(request.PhieuXuatDcKhoCtRequests);
                    foreach (var item in phieuXuatDcKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekhoNhap = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatDcKho,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = request.KhoNhapId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiCoTK,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            TkVatTu = item.GhiNoTK,
                            SoLuongNhap = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienNhap = item.Tien,
                            TienNhapVND = item.TienVND,
                        };
                        theKhos.Add(thekhoNhap);

                        var thekhoXuat = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatDcKho,
                            NgayHt = request.NgayHt,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = request.KhoNhapId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiNoTK,
                            NgoaiTeId = request.NgoaiTeId,
                            TyGia = request.TyGia,
                            VatTuId = item.VatTuId,
                            TkVatTu = item.GhiCoTK,
                            SoLuongXuat = item.SoLuong,
                            Gia = item.Gia,
                            GiaVND = item.GiaVND,
                            TienXuat = item.Tien,
                            TienXuatVND = item.TienVND,
                        };
                        theKhos.Add(thekhoXuat);
                        item.TheKhos = theKhos;
                    }
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuXuatDcKho = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuXuatDcKho.PhieuXuatDcKhoCts = phieuXuatDcKhoCts;
                phieuXuatDcKho.SoCais = soCais;
                await _repository.UpdateAsync(phieuXuatDcKho);
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
