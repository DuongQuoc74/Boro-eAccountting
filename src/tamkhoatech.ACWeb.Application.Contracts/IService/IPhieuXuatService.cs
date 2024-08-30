using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuXuatService : IApplicationService
    {
        Task<List<PhieuXuatDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay);
        Task<List<PhieuXuatDto>> GetListByKhachHangIdAsync(int? khachHangId);
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuXuatDto> phieuXuatDtos);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<PhieuXuatDto> GetHD1ByIdAsync(int? id);
        Task<PhieuXuatDto> GetHDAByIdAsync(int? id);
        Task<ApiResult> CreateAsync(PhieuXuatRequest request);
        Task<ApiResult> UpdateAsync(int? id, PhieuXuatRequest request);
        Task<ApiResult> DeleteAsync(int? id);
    }
}
