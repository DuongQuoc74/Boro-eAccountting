﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface ISoCaiService : IApplicationService
    {
        Task<List<SoCaiDto>> GetListAsync();
    }
}
