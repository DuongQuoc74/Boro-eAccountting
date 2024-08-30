using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace tamkhoatech.ACWeb.Service
{
    public class PhieuKeToanService : ApplicationService, IPhieuKeToanService
    {
        public readonly IRepository<PhieuKeToan, int?> _repository;
        public readonly IRepository<PhieuKeToanCt, int> _phieuKeToanCtRepository;
        public readonly IRepository<NgoaiTe, int?> _ngoaiTeRepository;
        public readonly IRepository<KhachHang, int?> _khachHangRepository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<HoaDonGtgt, int> _hoaDonGTGT;
        public readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public PhieuKeToanService(IRepository<PhieuKeToan, int?> repository, IRepository<NgoaiTe, int?> ngoaiTeRepository, 
            IRepository<PhieuKeToanCt, int> phieuKeToanCtRepository, IRepository<KhachHang, int?> khachHangRepository,
            IRepository<HoaDonGtgt, int> hoaDonGTGT, IRepository<SoCai, int?> soCairepository , IRepository<TaiKhoan, int?> taiKhoanRepository)
        {
            _repository = repository;
            _ngoaiTeRepository = ngoaiTeRepository;
            _phieuKeToanCtRepository = phieuKeToanCtRepository;
            _khachHangRepository = khachHangRepository;
            _hoaDonGTGT = hoaDonGTGT;
            _soCaiRepository = soCairepository;
            _taiKhoanRepository = taiKhoanRepository;
        }


        public async Task<ApiResult> CreateAsync(PhieuKeToanRequest request)
        {
            try
            {
                var phieuKtCts = new List<PhieuKeToanCt>();
                if (request.PhieuKeToanCtRequests != null)
                {
                    var groupedRecords = request.PhieuKeToanCtRequests.GroupBy(r => r.NhomDk);

                    foreach (var group in groupedRecords)
                    {
                        decimal? psNoVndPresent = 0;
                        decimal? psCoVndPresent = 0;
                        foreach (var record in group)
                        {
                            psNoVndPresent += record.PsNoVND;
                            psCoVndPresent += record.PsCoVND;
                        }
                        if (psNoVndPresent != psCoVndPresent)
                        {
                            return new ApiResult() { IsSuccessed = false, Message = $"Ps nợ khác ps có trong nhóm định khoản {group.Key}!" };
                        }
                    }
                    request.PhieuKeToanCtRequests.ForEach(item => item.Id = 0); 
                    phieuKtCts = ObjectMapper.Map<List<PhieuKeToanCtRequest>, List<PhieuKeToanCt>>(request.PhieuKeToanCtRequests);
                }
                var hoaDonGTGTs = new List<HoaDonGtgt>();
                if (request.HoaDonRequests != null)
                {
                    foreach (var item in request.HoaDonRequests)
                    {
                        if(item.SoCt0 == null)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập số hóa đơn Gtgt!" };
                        if (item.NgayCt0 == null)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập ngày hóa đơn Gtgt!" };
                        if (item.TkThue == null || item.TkThue == 0 )
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập tài khoản thuế trong hóa đơn Gtgt!" };
                        if (item.TkDu == null || item.TkDu == 0)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập tài khoản đối ứng trong hóa đơn Gtgt!" };
                    }
                    hoaDonGTGTs = ObjectMapper.Map<List<HoaDonRequest>, List<HoaDonGtgt>>(request.HoaDonRequests);
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuKt = ObjectMapper.Map<PhieuKeToanRequest, PhieuKeToan>(request);
                phieuKt.PhieuKeToanCts = phieuKtCts;
                phieuKt.HoaDonGTGTs = hoaDonGTGTs;
                phieuKt.SoCais = soCais;
                var result = await _repository.InsertAsync(phieuKt, true);
                return new ApiResult() { IsSuccessed = true, Id = result.Id, Message = "Thêm mới thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message ="Lỗi hệ thống, vui lòng liên hệ bộ phân kỹ thuật để được hỗ trợ." };
            }

        }

        public async Task<PhieuKeToanDto> GetByIdAsync(int? id)
        {
            try
            {
                var phieuKeToan = await _repository.GetAsync(id);
                var phieuKeToanCTs = await _phieuKeToanCtRepository.GetListAsync(x => x.PhieuKeToanId == id);
                var phieuKeToanCTDtos = ObjectMapper.Map<List<PhieuKeToanCt>, List<PhieuKeToanCtDto>>(phieuKeToanCTs);
                if (phieuKeToanCTDtos != null)
                {
                    foreach (var item in phieuKeToanCTDtos)
                    {
                        var khachHang = await _khachHangRepository.GetAsync(item.KhachHangId);
                        var tk = await _taiKhoanRepository.GetAsync(item.TaiKhoanId);
                        item.KhachHangUd = khachHang.KhachHangUd;
                        item.KhachHangNm = khachHang.KhachHangNm;
                        item.TaiKhoanUd = tk.TaiKhoanUd;

                    }
                }
                var hoaDonGTGTs = await _hoaDonGTGT.GetListAsync(x => x.PhieuKeToanId == id);
                var hoaDonGTGTDtos = ObjectMapper.Map<List<HoaDonGtgt>, List<HoaDonGtgtDto>>(hoaDonGTGTs);
                var phieuKeToanDto = ObjectMapper.Map<PhieuKeToan, PhieuKeToanDto>(phieuKeToan);
                phieuKeToanDto.PhieuKeToanCtDtos = phieuKeToanCTDtos;
                phieuKeToanDto.HoaDonGtgtDtos = hoaDonGTGTDtos;
                return phieuKeToanDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new PhieuKeToanDto();
            }
        }
        public async Task<int> GetCountByIdAsync(int? id)
        {
            return await _repository.CountAsync(x => x.Id == id);
        }

        public async Task<List<PhieuKeToanDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var phieuKts = ObjectMapper.Map<List<PhieuKeToan>, List<PhieuKeToanDto>>(await _repository.GetListAsync(x=>x.NgayHt >= tuNgay && x.NgayHt <= denNgay));
                foreach (var item in phieuKts)
                {
                    if (item.NgoaiTeId != null || item.NgoaiTeId != 0)
                    {
                        var nt = await _ngoaiTeRepository.GetAsync(x => x.Id == item.NgoaiTeId);
                        item.NgoaiTeUd = nt.NgoaiTeUd;
                    }
                    else
                        item.NgoaiTeUd = SystemConstants.NA;
                }
                return phieuKts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PhieuKeToanDto>();
            }
        }

        public async Task<ApiResult> UpdateAsync(int id, PhieuKeToanRequest request)
        {
            try
            {
                await _soCaiRepository.DeleteAsync(x => x.PhieuKeToanId == id);
                await _hoaDonGTGT.DeleteAsync(x => x.PhieuKeToanId == id);
                await _phieuKeToanCtRepository.DeleteAsync(x => x.PhieuKeToanId == id);
                var phieuKtCts = new List<PhieuKeToanCt>();
                if (request.PhieuKeToanCtRequests != null)
                {
                    var groupedRecords = request.PhieuKeToanCtRequests.GroupBy(r => r.NhomDk);

                    foreach (var group in groupedRecords)
                    {
                        decimal? psNoVndPresent = 0;
                        decimal? psCoVndPresent = 0;
                        foreach (var record in group)
                        {
                            psNoVndPresent += record.PsNoVND;
                            psCoVndPresent += record.PsCoVND;
                        }
                        if (psNoVndPresent != psCoVndPresent)
                        {
                            return new ApiResult() { IsSuccessed = false, Message = $"Ps nợ khác ps có trong nhóm định khoản {group.Key}!" };
                        }
                    }
                    request.PhieuKeToanCtRequests.ForEach(item => item.Id = 0);
                    phieuKtCts = ObjectMapper.Map<List<PhieuKeToanCtRequest>, List<PhieuKeToanCt>>(request.PhieuKeToanCtRequests);
                }
                var hoaDonGTGTs = new List<HoaDonGtgt>();
                if (request.HoaDonRequests != null)
                {
                    foreach (var item in request.HoaDonRequests)
                    {
                        if (item.SoCt0 == null)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập số hóa đơn Gtgt!" };
                        if (item.NgayCt0 == null)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập ngày hóa đơn Gtgt!" };
                        if (item.TkThue == null || item.TkThue == 0)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập tài khoản thuế trong hóa đơn Gtgt!" };
                        if (item.TkDu == null || item.TkDu == 0)
                            return new ApiResult() { IsSuccessed = false, Message = "Hãy nhập tài khoản đối ứng trong hóa đơn Gtgt!" };
                    }
                    hoaDonGTGTs = ObjectMapper.Map<List<HoaDonRequest>, List<HoaDonGtgt>>(request.HoaDonRequests);
                }
                var soCais = new List<SoCai>();
                if (request.SoCaiRequests != null)
                {
                    soCais = ObjectMapper.Map<List<SoCaiRequest>, List<SoCai>>(request.SoCaiRequests);
                }
                var phieuKeToan = ObjectMapper.Map(request, await _repository.GetAsync(id));
                phieuKeToan.HoaDonGTGTs = hoaDonGTGTs;
                phieuKeToan.PhieuKeToanCts = phieuKtCts;
                phieuKeToan.SoCais = soCais;
                await _repository.UpdateAsync(phieuKeToan);
                return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công !" };
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
                if (await _hoaDonGTGT.CountAsync(x => x.PhieuKeToanId == id) > 0)
                    await _hoaDonGTGT.DeleteAsync(x => x.PhieuKeToanId == id);
                await _soCaiRepository.DeleteAsync(x => x.PhieuKeToanId == id);
                await _phieuKeToanCtRepository.DeleteAsync(x => x.PhieuKeToanId == id);
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
                await _hoaDonGTGT.DeleteAsync(x => ids.Contains(x.PhieuKeToanId));
                await _soCaiRepository.DeleteAsync(x => ids.Contains(x.PhieuKeToanId));
                await _phieuKeToanCtRepository.DeleteAsync(x => ids.Contains(x.PhieuKeToanId));
                await _repository.DeleteManyAsync(ids);
                return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công !" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi hệ thống! Vui lòng bộ phận kỷ thuật để được hỗ trợ." };
            }
        }

        public async Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuKeToanDto> phieuKeToanDtos)
        {
            decimal? sumPhatSinh = 0;
            decimal? sumPhatSinhVND = 0;
            if (phieuKeToanDtos != null)
            {
                foreach (var item in phieuKeToanDtos)
                {
                    if (item.PsCo == null)
                        item.PsCo = 0;
                    sumPhatSinh += item.PsCo;
                    if (item.PsCoVND == null)
                        item.PsCoVND = 0;
                    sumPhatSinhVND += item.PsCoVND;
                }
            }
            var result = new TongTienDto()
            {
                SoLuongChungTu = phieuKeToanDtos != null ? phieuKeToanDtos.Count : 0,
                TongTienPhatSinh = sumPhatSinh,
                TongTienPhatSinhVND = sumPhatSinhVND

            };
            var resultTask = Task.FromResult(result);
            return await resultTask;
        }
    }
}
