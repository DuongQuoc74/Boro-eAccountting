using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface ITaiKhoanService : IApplicationService
    {
        Task<List<TaiKhoanDto>> GetListAsync();
        Task<TaiKhoanDto> GetByIdAsync(int? id);
    }
}
