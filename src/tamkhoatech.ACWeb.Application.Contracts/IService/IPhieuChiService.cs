﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.ThamSoHeThong;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuChiService : IApplicationService
    {
        Task<List<PhieuChiDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay);
        Task<PhieuChiDto> GetByIdAsync(int? id);
        Task<int> GetCountByIdAsync(int? id);
        Task<ApiResult> DeleteAsync(int? id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<ApiResult> DeleteListSoPhuOldAsync(string bankAccountNumber);
        Task<bool> DeletePhieuChiCTAsync(int id);
        Task<ApiResult> CreateAsync(PhieuChiRequest request);
        Task<ApiResult> UpdateAsync(int id, PhieuChiRequest request);
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuChiDto> phieuChiDtos);
        Task<GiaTriThamSoHeThongDto> GetGiaTriThamSoAsync();
    }
}
