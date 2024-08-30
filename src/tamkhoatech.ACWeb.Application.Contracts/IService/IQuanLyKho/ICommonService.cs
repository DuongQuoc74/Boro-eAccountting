﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyKho
{
    public interface  ICommonService : IApplicationService
    {
        Task<GiaTriTonKhoDto> GetTonKhos(int? vatTuId, int? khoId, DateTime? ngayHt, decimal? soLuong);
    }
}
