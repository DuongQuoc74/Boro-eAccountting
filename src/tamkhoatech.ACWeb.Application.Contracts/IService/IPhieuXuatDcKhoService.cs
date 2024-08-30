using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuXuatDcKhoService : IApplicationService
    {
        Task<List<PhieuXuatDcKhoDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay);
        Task<PhieuXuatDcKhoDto> GetByIdAsync(int? id);
        Task<ApiResult> CreateAsync(PhieuXuatDcKhoRequest request);
        Task<ApiResult> UpdateAsync(int id, PhieuXuatDcKhoRequest request);
        Task<ApiResult> DeleteAsync(int? id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<int> GetCountByIdAsync(int? id);
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuXuatDcKhoDto> phieuXuatDcKhoDtos);
    }
}
