using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuNhapService : IApplicationService
    {
        Task<List<PhieuNhapDto>> GetListByKhachHangIdAsync(int? khachHangId);
        Task<List<PhieuNhapDto>> FilterAsync(FilterRequest request);
        Task<List<PhieuNhapDto>> GetListAsync(string? loaiPhieu,DateTime? tuNgay, DateTime? denNgay);
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuNhapDto> phieuNhapDtos);
        Task<PhieuNhapDto> GetByIdAsync(int? id);
        Task<ApiResult> DeleteAsync(int? id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<int?> CreateAsync(PhieuNhapRequest request);
        Task<ApiResult> UpdateAsync(int id, PhieuNhapRequest request);
    }
}
