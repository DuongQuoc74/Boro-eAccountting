using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyHeThong
{
    public interface IManHinhNhapService : IApplicationService
    {
        Task<List<ManHinhNhapDto>> GetListAsync();
        Task<ManHinhNhapDto> GetByIdAsync(int id);
        Task<List<ManHinhNhapCtDto>> GetListManHinhNhapCtAsync(int? manHinhNhapId);
        Task<ApiResult> UpdateAsync(int? id, ManHinhNhapRequest request);
        Task<ApiResult> UpdateManHinhNhapCtAsync(List<ManHinhNhapCtDto> request);
        byte[] ExportExcel(List<ManHinhNhapDto> requests, string titleName);
    }
}
