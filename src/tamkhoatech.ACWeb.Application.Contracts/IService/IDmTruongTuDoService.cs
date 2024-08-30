using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IDmTruongTuDoService : IApplicationService
    {
        Task<List<DmTruongTuDoDto>> GetListLoai1Async();
        Task<List<DmTruongTuDoDto>> GetListLoai2Async();
        Task<List<DmTruongTuDoDto>> GetListLoai3Async();
    }
}
