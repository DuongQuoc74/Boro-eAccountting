using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IVatTuService : IApplicationService
    {
        Task<List<VatTuDto>> GetListAsync(string? danhMucChungUd);
        Task<List<NhomVatTuDto>> GetListNhomVatTuAsync(int? kieuPhanNhom);
        Task<VatTuDto> GetByIdAsync(int? id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<ApiResult> CreateAsync(VatTuRequest request);
        Task<ApiResult> UpdateAsync(int? id, VatTuRequest request);
        Task<VatTuDto?> GetByVatTuUdAsync(string vatTuUd);
        Task<ApiResult> GopMaAsync(int? id, int newId,string? newVatTuUd);
        Task<bool> CheckPhatSinh(int? id);
        byte[] ExportExcel(List<VatTuDto> requests, string titleName);
    }
}
