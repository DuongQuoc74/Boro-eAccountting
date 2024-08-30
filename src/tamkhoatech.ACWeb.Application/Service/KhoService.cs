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
    public class KhoService : ApplicationService, IKhoService
    {
        public readonly IRepository<Kho, int?> _repository;
        public readonly IRepository<ChiNhanh, int?> _chiNhanhRepository;
        public readonly IRepository<TheKho, int?> _theKhoRepository;

        public KhoService(IRepository<Kho, int?> repository, IRepository<ChiNhanh, int?> chiNhanhRepository, IRepository<TheKho, int?> theKhoRepository)
        {
            _repository = repository;
            _chiNhanhRepository = chiNhanhRepository;
            _theKhoRepository = theKhoRepository;
        }

        /// <summary>
        /// lấy danh sách kho hàng
        /// </summary>
        public async Task<List<KhoDto>> GetListAsync()
        {
            var result = ObjectMapper.Map<List<Kho>, List<KhoDto>>(await _repository.GetListAsync());
            // thông tin Ud và Nm từ các danh mục liên quan
            foreach (var item in result)
            {
                if (item.ChiNhanhId != 0)
                {
                    var cn = await _chiNhanhRepository.GetAsync(item.ChiNhanhId);
                    item.ChiNhanhUd = cn.ChiNhanhUd;
                    item.ChiNhanhNm = cn.ChiNhanhNm;
                }
                else
                {
                    item.ChiNhanhUd = SystemConstants.NA;
                    item.ChiNhanhNm = SystemConstants.NA;
                }
            }
            return result;
        }

        /// <summary>
        /// lấy thông tin kho hàng dựa theo ID
        /// </summary>
        public async Task<KhoDto> GetByIdAsync(int? id)
        {
            KhoDto kho = new KhoDto();
            try
            {
                kho = ObjectMapper.Map<Kho, KhoDto>(await _repository.GetAsync(id));
                // thông tin Ud và Nm từ các danh mục liên quan
                if (kho.ChiNhanhId != 0)
                {
                    var cn = await _chiNhanhRepository.GetAsync(kho.ChiNhanhId);
                    kho.ChiNhanhUd = cn.ChiNhanhUd;
                    kho.ChiNhanhNm = cn.ChiNhanhNm;
                }
                else
                {
                    kho.ChiNhanhUd = SystemConstants.NA;
                    kho.ChiNhanhNm = SystemConstants.NA;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (kho != null)
                return kho;
            return new KhoDto();
        }

        /// <summary>
        /// thêm mới
        /// </summary>
        public async Task<ApiResult> CreateAsync(KhoRequest request)
        {
            try
            {
                var count = await _repository.CountAsync(x => x.KhoUd == request.KhoUd);
                if (count > 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Mã kho đã tồn tại!" };
                }
                var _kho = ObjectMapper.Map<KhoRequest, Kho>(request);
                await _repository.InsertAsync(_kho, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ApiResult() { IsSuccessed = false, Message = "Lỗi! Vui lòng liên hệ bộ phận kỹ thuật để được hỗ trợ." };
            }
            return new ApiResult() { IsSuccessed = true, Message = "Thêm mới thành công!" };
        }

        /// <summary>
        /// chỉnh sửa
        /// </summary>
        public async Task<ApiResult> UpdateAsync(int id, KhoRequest request)
        {
            try
            {
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

        /// <summary>
        /// xóa
        /// </summary>
        public async Task<ApiResult> DeleteAsync(int id)
        {
            try
            {
                var theKho = await _theKhoRepository.CountAsync(x => x.KhoId == id);
                if (theKho > 0)
                {
                    return new ApiResult() { IsSuccessed = false, Message = "Đã có phát sinh, không xóa được!" };
                }
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
    }
}
