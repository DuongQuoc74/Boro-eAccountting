using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IChiNhanhService : IApplicationService
    {
        Task<List<ChiNhanhDto>> GetListAsync();
        Task<ChiNhanhDto> GetByIdAsync(int? id);
        Task<ChiNhanhDto> FirstOrDefaultAsync();
        Task<ApiResult> CreateAsync(ChiNhanhRequest request);
        Task<ApiResult> UpdateAsync(int? id, ChiNhanhRequest request);
        Task<ApiResult> DeleteAsync(int id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
    }
}
