using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IMaGiaoDichService : IApplicationService
    {
        Task<List<MaGiaoDichDto>> GetListAsync(string maCt);
        Task<MaGiaoDichDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
