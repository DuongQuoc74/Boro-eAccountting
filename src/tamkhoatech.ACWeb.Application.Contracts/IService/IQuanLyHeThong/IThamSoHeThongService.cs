using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.DTO.QuanLyHeThong.ThamSoHeThong;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService.IQuanLyHeThong
{
    public interface IThamSoHeThongService : IApplicationService
    {
        Task<List<ThamSoHeThongDto>> GetListAsync(string nhomThamSo);
        Task<ThamSoHeThongDto> GetByIdAsync(int id);
        Task<ThamSoHeThongDto> GetByThamSoHeThongUdAsync(string thamSoHeThongUd);
        Task<ApiResult> UpdateAsync(int id, string? value);
        Task<int> CachLayDienGiaiKhiTaoTuDongPhieuThuChiAsync(int loaithamsocanlay);
        Task<int> TuDongTaoThuChiAsync();
        string GioiHanKyTu(string inputString, int limit);
    }
}
