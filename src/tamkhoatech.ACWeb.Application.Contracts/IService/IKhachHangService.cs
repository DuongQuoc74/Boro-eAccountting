using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.IService
{
    public interface IKhachHangService: IApplicationService
    {
        Task<List<KhachHangDto>> GetListAsync(int loai);
        Task<KhachHangDto> GetByIdAsync(int? id);
        Task<KhachHangDto?> GetByKhachHangUdAsync(string khachHangUd);
        Task<string[]> TraCuuAsync(string mst);
        Task<ApiResult> DeleteAsync(int id);
        Task<ApiResult> DeleteListAsync(List<int?> ids);
        Task<ApiResult> CreateAsync(KhachHangRequest request);
        Task<ApiResult> UpdateAsync(int? id, KhachHangRequest request);
        Task<ApiResult> GopMaAsync(int? id, int newId, string? newKhachHangUd);

        Task<List<NhomKhachHangDto>> GetListNhomKhachHangAsync(int loai);
        Task<bool> CheckPhatSinh (int? id);
        byte[] ExportExcel(List<KhachHangDto> requests,string titleName);
    }
}
