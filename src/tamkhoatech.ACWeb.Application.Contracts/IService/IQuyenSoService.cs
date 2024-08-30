using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IQuyenSoService : IApplicationService
    {
        Task<List<QuyenSoDto>> GetListAsync(string maCt);
        Task<bool> UpdateSoCTAsync(string maCt, string soQuyen, string soPhieu);
        Task<ApiResult> CreateAsync (QuyenSoDto quyenSoDTO);
    }
}
