using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IPhieuNhapKhoService : IApplicationService
    {
        Task<List<PhieuNhapKhoDto>> GetListAsync(DateTime? tuNgay, DateTime? denNgay); // lấy danh sách chứng từ
        Task<TongTienDto> TongTienPhatSinhAsync(List<PhieuNhapKhoDto> phieuNhapKhoDtos);
        Task<PhieuNhapKhoDto> GetByIdAsync(int? id); // lấy một chứng từ theo ID
        Task<int> GetCountByIdAsync(int? id); // đếm số lượng chứng từ
        Task<ApiResult> CreateAsync(PhieuNhapKhoRequest request); // thêm chứng từ
        Task<ApiResult> UpdateAsync(int id, PhieuNhapKhoRequest request); // sửa chứng từ
        Task<ApiResult> DeleteAsync(int? id); // xóa chứng từ
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<bool> DeletePhieuNhapKhoCtAsync(int id);
    }
}
