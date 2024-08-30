using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyMuaHang
{
    public interface  ICommonService : IApplicationService
    {
        Task<ApiResult> TaoPhieuChiAsync(int? id, PhieuNhapRequest request);
    }
}
