using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Dto.Common;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService.IQuanLyHeThong;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service.QuanLyHeThong
{
    public class ManHinhNhapService : ApplicationService, IManHinhNhapService
    {
        public readonly IRepository<ManHinhNhap, int?> _repository;
        public readonly IRepository<ManHinhNhapCt, int> _manHinhNhapCtrepository;
        public readonly IUtilitiesService _utilitiesService;
        public ManHinhNhapService(IRepository<ManHinhNhap, int?> repository, IRepository<ManHinhNhapCt, int> manHinhNhapCtrepository, IUtilitiesService utilitiesService)
        {
            _repository = repository;
            _manHinhNhapCtrepository = manHinhNhapCtrepository;
            _utilitiesService = utilitiesService;
        }

        public byte[] ExportExcel(List<ManHinhNhapDto> requests, string titleName)
        {
            var package = _utilitiesService.CreateExcelTemplate(requests.Count, 6, titleName);
            var worksheet = package.Workbook.Worksheets[titleName];

            // Tạo tên cột
            worksheet.Cells[4, 1].Value = "Mã chứng từ";
            worksheet.Cells[4, 2].Value = "Tên chứng từ";
            worksheet.Cells[4, 3].Value = "Tên 2";
            worksheet.Cells[4, 4].Value = "Số liên";
            worksheet.Cells[4, 5].Value = "Mã chứng từ in";
            worksheet.Cells[4, 6].Value = "Số thứ tự in";
            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 12;
            worksheet.Column(2).Width = 30;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 12;
            worksheet.Column(5).Width = 14;
            worksheet.Column(6).Width = 12;
            worksheet.Cells[2, 1, 2, 6].Merge = true;//Set vị trí hiển thị title ==> Tổng width của cột phải không quá 210
            //Đọc dữ liệu
            int rowStart = 5; // bắt đầu từ row 5
            if(requests.Count > 0)
            {
                foreach (var item in requests)
                {
                    worksheet.Cells[rowStart, 1].Value = item.ChungTuUd;
                    worksheet.Cells[rowStart, 2].Value = item.ChungTuNm;
                    worksheet.Cells[rowStart, 3].Value = item.ChungTuNm2;
                    worksheet.Cells[rowStart, 4].Value = item.SoLien;
                    worksheet.Cells[rowStart, 5].Value = item.MaCtIn;
                    worksheet.Cells[rowStart, 6].Value = item.SttInBangKe;
                    rowStart++;
                }
            }

            return package.GetAsByteArray();
        }

        public async Task<ManHinhNhapDto> GetByIdAsync(int id)
        {
            return ObjectMapper.Map<ManHinhNhap, ManHinhNhapDto>( await _repository.GetAsync(id));
        }

        public async Task<List<ManHinhNhapDto>> GetListAsync()
        {
            return ObjectMapper.Map<List<ManHinhNhap>, List<ManHinhNhapDto>>(await _repository.GetListAsync());
        }

        public async Task<List<ManHinhNhapCtDto>> GetListManHinhNhapCtAsync(int? manHinhNhapId)
        {
            return ObjectMapper.Map<List<ManHinhNhapCt>, List<ManHinhNhapCtDto>>(await _manHinhNhapCtrepository.GetListAsync(x => x.ManHinhNhapId == manHinhNhapId));
        }

        public async Task<ApiResult> UpdateAsync(int? id, ManHinhNhapRequest request)
        {
            try
            {
                var item = ObjectMapper.Map(request, await _repository.GetAsync(id));
                await _repository.UpdateAsync(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new ApiResult() { IsSuccessed = true, Message = "Cập nhật thành công!" };
        }

        public async Task<ApiResult> UpdateManHinhNhapCtAsync(List<ManHinhNhapCtDto> request)
        {
            try
            {
                var items = ObjectMapper.Map<List<ManHinhNhapCtDto>, List<ManHinhNhapCt>>(request);
                await _manHinhNhapCtrepository.UpdateManyAsync(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new ApiResult() { IsSuccessed = true, Message = "Cập nhật thành công!" };
        }
    }
}
