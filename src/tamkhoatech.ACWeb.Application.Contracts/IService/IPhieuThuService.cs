using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuThuService : IApplicationService
    {
        Task<List<PhieuThuDto>> GetListAsync(string loaiPhieu, DateTime? tuNgay, DateTime? denNgay);
        Task<PhieuThuDto> GetByIdAsync(int? id);
        Task<int> GetCountByIdAsync(int? id);
        Task<ApiResult> DeleteAsync(int? id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<ApiResult> DeleteListSoPhuOldAsync(string bankAccountNumber);
        Task<ApiResult> CreateAsync(PhieuThuRequest request);
        Task<ApiResult> UpdateAsync(int id, PhieuThuRequest request);
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuThuDto> phieuThuDtos);
    }
}
