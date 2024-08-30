using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyCongNo;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy;
using Volo.Abp.Application.Services;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Dto;

namespace tamkhoatech.ACWeb.IService.IQuanLyHeThong
{
    public interface IDuDauKyCongNoService : IApplicationService
    {
        Task<List<DuDauKyCongNoDto>> GetListAsync(DauKyRequest request);
        Task<DuDauKyCongNoDto> GetByIdAsync(int? id);
        Task<ApiResult> CreateAsync(DuDauKyCongNoRequest request);
        Task<ApiResult> UpdateAsync(int? id, DuDauKyCongNoRequest request);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<List<TinhTongDto>> TinhTongAsync(int? taiKhoanId, int? khachHangId, List<DuDauKyCongNoDto> duDauKyCongNoDtos);
        byte[] ExportExcel(List<DuDauKyCongNoDto> requests, string titleName);
    }
}
