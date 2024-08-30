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
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuNhapKhoService : ApplicationService, IPhieuNhapKhoService
    {
        public readonly IRepository<PhieuNhapKho, int?> _repository;
        public readonly IRepository<PhieuNhapKhoCt, int> _phieuNhapKhoCtRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;
        public readonly IRepository<KhachHang, int?> _khachHangRepository;
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<VatTu, int?> _vatTuRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public readonly IRepository<ChiNhanh, int?> _chiNhanhRepository;
        public readonly IRepository<DMChung, int?> _giaoDichRepository;

        public PhieuNhapKhoService(IRepository<PhieuNhapKho, int?> phieuNhapKhoRepository, IRepository<PhieuNhapKhoCt, int> phieuNhapKhoCtRepository, IRepository<TheKho, int?> theKhoRepository, IRepository<SoCai, int?> soCaiRepository,
            IRepository<KhachHang, int?> khachHangRepository, IRepository<NgoaiTe, int?> ngoaiTeRepository, IRepository<VatTu, int?> vatTuRepository, IRepository<Kho, int?> khoRepository,IRepository<TaiKhoan, int?> taiKhoanRepository, 
            IRepository<ChiNhanh, int?> chiNhanhRepository, IRepository<DMChung, int?> giaoDichRepository)
        {
            _repository = phieuNhapKhoRepository;
            _phieuNhapKhoCtRepository = phieuNhapKhoCtRepository;
            _soCaiRepository = soCaiRepository;
            _theKhoRepository = theKhoRepository;
            _khachHangRepository = khachHangRepository;
            _ngoaiTeRepository = ngoaiTeRepository;
            _vatTuRepository = vatTuRepository;
            _khoRepository = khoRepository;
            _taiKhoanRepository = taiKhoanRepository;
            _chiNhanhRepository = chiNhanhRepository;
            _giaoDichRepository = giaoDichRepository;
        }

        public async Task<List<PhieuNhapKhoDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var query = await _repository.GetQueryableAsync();
                query = query.Where(x => x.NgayHT >= tuNgay && x.NgayHT <= denNgay);
                var result = await AsyncExecuter.ToListAsync(query);
                var items = ObjectMapper.Map<List<PhieuNhapKho>, List<PhieuNhapKhoDto>>(result);
                foreach (var item in items)
                {
                    if(item.KhachHangId.HasValue && item.KhachHangId != 0)
                    {
                        var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id == item.KhachHangId);
                        item.KhachHangUd = kh?.KhachHangUd;
                    }
                    if (item.NgoaiTeId.HasValue && item.NgoaiTeId != 0)
                    {
                        var kh = await _ngoaiTeRepository.FirstOrDefaultAsync(x => x.Id == item.NgoaiTeId);
                        item.NgoaiTeUd = kh?.NgoaiTeUd;
                    }
                }
                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuNhapKhoDto>();
            }
        }

        public async Task<PhieuNhapKhoDto> GetByIdAsync(int? id)
        {
            var phieuNhapKhoCts = await _phieuNhapKhoCtRepository.GetListAsync(x => x.PhieuNhapKhoId == id);
            var phieuNhapKhoCtDtos = ObjectMapper.Map<List<PhieuNhapKhoCt>, List<PhieuNhapKhoCtDto>>(phieuNhapKhoCts);
            foreach (var item in phieuNhapKhoCtDtos)
            {
                var vt = await _vatTuRepository.FirstOrDefaultAsync(x=>x.Id == item.VatTuId);
                var kho = await _khoRepository.FirstOrDefaultAsync(x => x.Id == item.KhoId);
                var tkNo = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiNoTK);
                var tkCo = await _taiKhoanRepository.FirstOrDefaultAsync(x => x.Id == item.GhiCoTK);
                item.VatTuUd = vt?.VatTuUd;
                item.VatTuNm = vt?.VatTuNm;
                item.DonViTinh = vt?.DonViTinh;
                item.KhoUd = kho?.KhoUd;
                item.GhiNoTkUd = tkNo?.TaiKhoanUd;
                item.GhiCoTkUd = tkCo?.TaiKhoanUd;
            }
            var phieuNhapKhoDto = ObjectMapper.Map<PhieuNhapKho, PhieuNhapKhoDto>(await _repository.GetAsync(id));
            if(phieuNhapKhoDto.KhachHangId.HasValue && phieuNhapKhoDto.KhachHangId != 0)
            {
                var kh = await _khachHangRepository.FirstOrDefaultAsync(x => x.Id == phieuNhapKhoDto.KhachHangId);
                phieuNhapKhoDto.KhachHangNm = kh?.KhachHangNm;
                phieuNhapKhoDto.DiaChi = kh?.DiaChi;
            }
            if (phieuNhapKhoDto.ChiNhanhId.HasValue && phieuNhapKhoDto.ChiNhanhId != 0)
            {
                var kh = await _chiNhanhRepository.FirstOrDefaultAsync(x => x.Id == phieuNhapKhoDto.ChiNhanhId);
                phieuNhapKhoDto.ChiNhanhNm = kh?.ChiNhanhNm;
            }
            if(phieuNhapKhoDto.GiaoDichId.HasValue && phieuNhapKhoDto.GiaoDichId != 0)
            {
                var kh = await _giaoDichRepository.FirstOrDefaultAsync(x => x.Id == phieuNhapKhoDto.GiaoDichId);
                phieuNhapKhoDto.GiaoDichNm = kh?.DMChungNm;
            }
            phieuNhapKhoDto.PhieuNhapKhoCtDtos = phieuNhapKhoCtDtos;

            return phieuNhapKhoDto;
        }

        public async Task<int> GetCountByIdAsync(int? id)
        {
            return await _repository.CountAsync(x => x.Id == id);
        }

        public async Task<ApiResult> CreateAsync(PhieuNhapKhoRequest request)
        {
            try
            {
                var phieuNhapKhoCts = new List<PhieuNhapKhoCt>();
                if (request.PhieuNhapKhoCtRequests != null)
                {
                    request.PhieuNhapKhoCtRequests.ForEach(item => item.Id = 0);
                    phieuNhapKhoCts = ObjectMapper.Map<List<PhieuNhapKhoCtRequest>, List<PhieuNhapKhoCt>>(request.PhieuNhapKhoCtRequests);
                    foreach (var item in phieuNhapKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekhoNhap = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuNhapKho,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = item.KhoId,
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
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhoId = item.KhoId,
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

                var phieuNhapKho = ObjectMapper.Map<PhieuNhapKhoRequest, PhieuNhapKho>(request);
                phieuNhapKho.PhieuNhapKhoCts = phieuNhapKhoCts;
                phieuNhapKho.SoCais = soCais;
                var result = await _repository.InsertAsync(phieuNhapKho, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống, vui lòng liên hệ bộ phân kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuNhapKhoRequest request)
        {
            try
            {
                var phieuNhapKhoCts = await _phieuNhapKhoCtRepository.GetListAsync(x => x.PhieuNhapKhoId == id);
                foreach (var item in phieuNhapKhoCts)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuNhapKhoCtId == item.Id);
                }
                await _soCaiRepository.DeleteAsync(x => x.PhieuNhapKhoId == id);
                await _phieuNhapKhoCtRepository.DeleteAsync(x => x.PhieuNhapKhoId == id);

                phieuNhapKhoCts = new List<PhieuNhapKhoCt>();
                if (request.PhieuNhapKhoCtRequests != null)
                {
                    request.PhieuNhapKhoCtRequests.ForEach(x => x.Id = 0);
                    phieuNhapKhoCts = ObjectMapper.Map<List<PhieuNhapKhoCtRequest>, List<PhieuNhapKhoCt>>(request.PhieuNhapKhoCtRequests);
                    foreach (var item in phieuNhapKhoCts)
                    {
                        var theKhos = new List<TheKho>();
                        var thekho = new TheKho()
                        {
                            MaNk = SystemConstants.LoaiPhieu.PhieuXuatKho,
                            MaGd = request.GiaoDichId,
                            NgayHt = request.NgayHT,
                            NgayLap = request.NgayLap,
                            SoCt = request.SoCt,
                            KhachHangId = request.KhachHangId,
                            KhoId = item.KhoId,
                            DienGiai = request.DienGiai,
                            GhiNoCoTk = item.GhiCoTK,
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

                var phieuNhapKho = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuNhapKho.PhieuNhapKhoCts = phieuNhapKhoCts;
                phieuNhapKho.SoCais = soCais;
                await _repository.UpdateAsync(phieuNhapKho);
                return new ApiResult() { IsSuccessed = true, Id = id, Message = "Cập nhật thành công!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteAsync(int? id)
        {
            try
            {
                var phieuNhapKhoCts = await _phieuNhapKhoCtRepository.GetListAsync(x => x.PhieuNhapKhoId == id);
                foreach (var item in phieuNhapKhoCts)
                {
                    await _theKhoRepository.DeleteAsync(x => x.PhieuNhapKhoCtId == item.Id);

                }
                await _soCaiRepository.DeleteAsync(x => x.PhieuNhapKhoId == id);
                await _phieuNhapKhoCtRepository.DeleteAsync(x => x.PhieuNhapKhoId == id);
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
            return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
        }

        public async Task<bool> DeletePhieuNhapKhoCtAsync(int id)
        {
            try
            {
                if (id == 0)
                    return false;
                await _phieuNhapKhoCtRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuNhapKhoDto> phieuNhapKhoDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuNhapKhoDtos != null)
            {
                foreach (var item in phieuNhapKhoDtos)
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
                SoLuongChungTu = phieuNhapKhoDtos != null ? phieuNhapKhoDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var ct = await _phieuNhapKhoCtRepository.GetListAsync(x => x.PhieuNhapKhoId == id);
                    foreach (var item in ct)
                    {
                        await _theKhoRepository.DeleteAsync(x => x.PhieuNhapKhoCtId == item.Id);
                    }
                }
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapKhoId));
                await _phieuNhapKhoCtRepository.DeleteAsync(x => ids.Contains(x.PhieuNhapKhoId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };

            }
        }
    }
}
