using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.IService.IUtilities;
using Volo.Abp.Application.Services;

namespace tamkhoatech.ACWeb.Service.Utilities
{
    public class UtilitiesService : ApplicationService, IUtilitiesService
    {
        public ExcelPackage CreateExcelTemplate(int countRow, int countColumn, string titleName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();
            try
            {
                //Đặt tên cho sheet1
                var worksheet = package.Workbook.Worksheets.Add(titleName);
                // Định dạng title
                worksheet.Cells[2, 1].Value = titleName.ToUpper();
                worksheet.Cells[2, 1].Style.Font.Bold = true;
                worksheet.Cells[2, 1].Style.Font.Size = 16;
                worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // căn giữa theo chiều ngang
                worksheet.Cells[2, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center; // căn giữa theo chiều dọc

                Color lightBlueHex = ColorTranslator.FromHtml("#d7e7f5");
                // Định dạng header
                worksheet.Row(4).Height = 30;
                using (var range = worksheet.Cells[4, 1, 4, countColumn])
                {
                    range.Style.Font.Bold = true;//set chữ in đậm
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // căn giữa theo chiều ngang
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center; // căn giữa theo chiều dọc
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid; // Chỉ định kiểu điền màu
                    range.Style.Fill.BackgroundColor.SetColor(lightBlueHex); // Set màu nền
                    range.Style.WrapText = true;//Tự động xuống dòng
                    range.Style.Font.Size = 10;
                }
                //Kiểm tra dữ liệu khác null
                if (countRow > 0)
                {
                    // Định dạng body
                    using (var range = worksheet.Cells[5, 1, 5 + countRow, countColumn])
                    {
                       
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;//căn trái
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center; // căn giữa theo chiều dọc
                        range.Style.WrapText = true;//Tự động xuống dòng
                        range.Style.Font.Size = 9;
                    }
                    // Định dạng số dòng
                    using (var range = worksheet.Cells[5 + countRow + 1, 1, 5 + countRow + 1, 1])
                    {
                        range.Value = $"Số dòng: {countRow}";
                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;//căn trái
                        range.Style.VerticalAlignment = ExcelVerticalAlignment.Center; // căn giữa theo chiều dọc
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid; // Chỉ định kiểu điền màu
                        range.Style.Fill.BackgroundColor.SetColor(lightBlueHex); // Set màu nền
                        range.Style.WrapText = true;//Tự động xuống dòng
                        range.Style.Font.Size = 9;
                    }
                }
                // Thiết lập đường viền cho từng ô trong phạm vi
                using (var range = worksheet.Cells[4, 1, 5 + countRow, countColumn])
                {
                    range.Select(cell => cell.Style)
                         .ToList()
                         .ForEach(style =>
                         {
                             style.Border.Top.Style = ExcelBorderStyle.Thin;
                             style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                             style.Border.Left.Style = ExcelBorderStyle.Thin;
                             style.Border.Right.Style = ExcelBorderStyle.Thin;
                         });
                }

                // Thiết lập kiểu chữ
                foreach (var cell in worksheet.Cells)
                {
                    cell.Style.Font.Name = "Times New Roman";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return package;
        }

        public async Task<DateTime?> DefultNgayHt(DateTime? fromDate, DateTime? toDate)
        {
            var value = DateTime.Now;
            if (toDate.HasValue && fromDate.HasValue && (value < fromDate || value >= toDate.Value.AddDays(1)))
            {
                return await Task.FromResult(toDate);
            }
            return await Task.FromResult(value);
        }
    }
}
