using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyBanHang
{
    public interface  ICommonService : IApplicationService
    {
        Task<ApiResult> TaoPhieuThuHD1Async(int? id, PhieuXuatRequest request);
        Task<ApiResult> TaoPhieuThuHDAAsync(int? id, PhieuXuatRequest request);
    }
}
