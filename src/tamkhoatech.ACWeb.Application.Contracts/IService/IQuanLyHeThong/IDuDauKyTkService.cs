using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyTk;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyHeThong
{
    public interface IDuDauKyTkService : IApplicationService
    {
        Task<List<DuDauKyTkDto>> GetListAsync(DauKyRequest request, bool isDeleted = false);
        Task<DuDauKyTkDto> GetByIdAsync(int? id);
        Task<ApiResult> UpdateAsync(int? id, DuDauKyTkRequest request);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<List<TinhTongDto>> TinhTongAsync(int? taiKhoanId, List<DuDauKyTkDto> duDauKyTkDtos);
        byte[] ExportExcel(List<DuDauKyTkDto> requests, string titleName);
    }
}
