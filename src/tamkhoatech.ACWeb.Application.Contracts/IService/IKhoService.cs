using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IKhoService : IApplicationService
    {
        /// <summary>
        /// lấy danh sách kho hàng
        /// </summary>
        Task<List<KhoDto>> GetListAsync();
        /// <summary>
        /// lấy thông tin kho hàng dựa theo ID
        /// </summary>
        Task<KhoDto> GetByIdAsync(int? id);
        /// <summary>
        /// thêm mới
        /// </summary>
        Task<ApiResult> CreateAsync(KhoRequest request);
        /// <summary>
        /// chỉnh sửa
        /// </summary>
        Task<ApiResult> UpdateAsync(int id, KhoRequest request);
        /// <summary>
        /// xóa
        /// </summary>
        Task<ApiResult> DeleteAsync(int id);
    }
}
