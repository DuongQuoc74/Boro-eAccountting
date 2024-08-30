using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IDMChungService : IApplicationService
    {
        Task<List<DmChungDto>> GetListAsync(string? loaiDM);
        Task<DmChungDto?> GetByIdAsync(string? loaiDM, string? danhMucChungUd);
    }
}
