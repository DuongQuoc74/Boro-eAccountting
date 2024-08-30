using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class ChiNhanhService : ApplicationService, IChiNhanhService
    {
        public readonly IRepository<ChiNhanh, int?> _repository;
        public readonly IRepository<SoCai, int?> _soCaiRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;
        public readonly IRepository<Kho, int?> _khoRepository;
        public readonly IRepository<DuDauKyCongNo, int?> _duDauKyCongNoRepository;

        public ChiNhanhService(IRepository<ChiNhanh, int?> repository, IRepository<SoCai, int?> soCaiRepository, IRepository<TheKho, int?> theKhoRepository, IRepository<DuDauKyCongNo, int?> duDauKyCongNoRepository, IRepository<Kho, int?> khoRepository)
        {
            _repository = repository;
            _soCaiRepository = soCaiRepository;
            _theKhoRepository = theKhoRepository;
            _duDauKyCongNoRepository = duDauKyCongNoRepository;
            _khoRepository = khoRepository;
        }

        public async Task<List<ChiNhanhDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<ChiNhanh>, List<ChiNhanhDto>>(await _repository.GetListAsync());
        }

        public async Task<ChiNhanhDto> GetByIdAsync(int? id)
        {
            return ObjectMapper.Map<ChiNhanh, ChiNhanhDto>(await _repository.GetAsync(id));
        }

        public async Task<ChiNhanhDto> FirstOrDefaultAsync()
        {
            var cn = await _repository.FirstOrDefaultAsync();
            if (cn == null)
                return new ChiNhanhDto();
            return ObjectMapper.Map<ChiNhanh, ChiNhanhDto>(cn);
        }

        public async Task<ApiResult> CreateAsync(ChiNhanhRequest request)
        {
            try
            {
                var count = await _repository.CountAsync(x => x.ChiNhanhUd == request.ChiNhanhUd);
                if (count > 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã chi nhánh đã tồn tại!" };
                }
                var chiNhanh = ObjectMapper.Map<ChiNhanhRequest, ChiNhanh>(request);
                await _repository.InsertAsync(chiNhanh, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
            return new ApiResult() { IsSuccessed = true, Message = "Thêm mới thành công!" };
        }

        public async Task<ApiResult> UpdateAsync(int? id, ChiNhanhRequest request)
        {
            try
            {
                var cn = await _repository.GetAsync(id);
                if (cn.ChiNhanhUd != request.ChiNhanhUd && await _repository.CountAsync(x => x.ChiNhanhUd == request.ChiNhanhUd) > 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã chi nhánh đã tồn tại!" };
                }
                var item = ObjectMapper.Map(request, await _repository.GetAsync(id));
                await _repository.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
            return new ApiResult() { IsSuccessed = true, Message = "Chỉnh sửa thành công!" };
        }

        public async Task<ApiResult> DeleteAsync(int id)
        {
            try
            {
                var soCai = await _soCaiRepository.CountAsync(x => x.ChiNhanhId == id);
                var theKho = await _theKhoRepository.CountAsync(x => x.ChiNhanhId == id);
                var duDauKyCongNo = await _duDauKyCongNoRepository.CountAsync(x => x.ChiNhanhId == id);
                if (soCai > 0 || theKho > 0 || duDauKyCongNo > 0)
                    return new ApiResult() { IsSuccessed = false, Message = "Đã có phát sinh, không xóa được!" };
                else
                {
                    await _repository.DeleteAsync(id);
                    return new ApiResult() { IsSuccessed = true, Message = "Xóa thành công!" };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
        }

        public async Task<ApiResult> DeleteListAsync(List<int?> ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    var soCai = await _soCaiRepository.CountAsync(x => x.ChiNhanhId == id);
                    if(soCai > 0)
                    {
                        var cn = await _repository.GetAsync(id);
                        return new ApiResult() { IsSuccessed = false, Message = $"Mã chi nhánh <b>{cn.ChiNhanhUd}</b> đã có phát sinh, không xóa được!" };
                    }    
                    var theKho = await _theKhoRepository.CountAsync(x => x.ChiNhanhId == id);
                    if (theKho > 0)
                    {
                        var cn = await _repository.GetAsync(id);
                        return new ApiResult() { IsSuccessed = false, Message = $"Mã chi nhánh <b>{cn.ChiNhanhUd}</b> đã có phát sinh, không xóa được!" };
                    }    
                    var duDauKyCongNo = await _duDauKyCongNoRepository.CountAsync(x => x.ChiNhanhId == id);
                    if(duDauKyCongNo > 0)
                    {
                        var cn = await _repository.GetAsync(id);
                        return new ApiResult() { IsSuccessed = false, Message = $"Mã chi nhánh <b>{cn.ChiNhanhUd}</b> đã có phát sinh, không xóa được!" };
                    }
                    var kho = await _khoRepository.CountAsync(x => x.ChiNhanhId == id);
                    if (kho > 0)
                    {
                        var cn = await _repository.GetAsync(id);
                        return new ApiResult() { IsSuccessed = false, Message = $"Mã chi nhánh <b>{cn.ChiNhanhUd}</b> đã có phát sinh, không xóa được!" };
                    }
                }
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
