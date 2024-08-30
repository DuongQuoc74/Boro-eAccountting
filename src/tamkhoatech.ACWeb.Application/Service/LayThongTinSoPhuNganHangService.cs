using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tamkhoatech.ACWeb.Constants;
using tamkhoatech.ACWeb.Dto;
using tamkhoatech.ACWeb.Entities;
using tamkhoatech.ACWeb.IService;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace tamkhoatech.ACWeb.Service
{
    public class LayThongTinSoPhuNganHangService : ApplicationService, ILayThongTinSoPhuNganHangService
    {
        private readonly IRepository<SoPhuSupport, int?> _soPhuSupportRepository;
        private readonly IRepository<KhachHang, int?> _khachHangRepository;
        private readonly IRepository<TaiKhoan, int?> _taiKhoanRepository;
        public LayThongTinSoPhuNganHangService(IRepository<SoPhuSupport, int?> soPhuSupportRepository, IRepository<KhachHang, int?> khachHangRepository, IRepository<TaiKhoan, int?> taiKhoanRepository)
        {
            _soPhuSupportRepository = soPhuSupportRepository;
            _khachHangRepository = khachHangRepository;
            _taiKhoanRepository = taiKhoanRepository;
        }

        public byte[] ExportExcel(SoPhuNganHangDto request)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sổ phụ ngân hàng");

            // Tạo tên cột
            worksheet.Cells[2, 1].Value = "Số tài khoản (*)";
            worksheet.Cells[4, 1].Value = "Ngày (*)";
            worksheet.Cells[4, 2].Value = "Diễn Giải (*)";
            worksheet.Cells[4, 3].Value = "Phát sinh nợ (*)";
            worksheet.Cells[4, 4].Value = "Phát sinh có (*)";
            worksheet.Cells[4, 5].Value = "Tài khoản ngân hàng (*)";
            worksheet.Cells[4, 6].Value = "Tài khoản đối ứng (*)";
            worksheet.Cells[4, 7].Value = "Mã khách hàng (*)";

            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 25;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 20;
            worksheet.Column(4).Width = 25;
            worksheet.Column(5).Width = 25;
            worksheet.Column(6).Width = 25;
            worksheet.Column(7).Width = 25;
            using (var range = worksheet.Cells[4, 1, 4, 7])
            {
                range.Style.Font.Bold = true;
                //range.Style.Fill.PatternType = ExcelFillStyle.Solid; //set Pattern
                //range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray); // Set color
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            //add data
            worksheet.Cells[1, 1].Value = "Ngân hàng: ";
            worksheet.Cells[1, 2].Value = request.TenNganHang;
            worksheet.Cells[2, 2].Value = request.SoTaiKhoan;

            if (request.DataSoPhus != null)
            {
                int row = 5;
                foreach (var item in request.DataSoPhus)
                {
                    worksheet.Cells[row, 1].Value = item.Ngay.ToString();
                    worksheet.Cells[row, 2].Value = item.DienGiai;
                    worksheet.Cells[row, 3].Value = (item.PsNoVND ?? 0).ToString("N0");
                    worksheet.Cells[row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[row, 4].Value = (item.PsCoVND ?? 0).ToString("N0");
                    worksheet.Cells[row, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    worksheet.Cells[row, 5].Value = request.TaiKhoanNganHang;
                    worksheet.Cells[row, 6].Value = item.TkDuUd;
                    worksheet.Cells[row, 7].Value = item.KhachHangUd;
                    row++;
                }
            }

            return package.GetAsByteArray();
        }

        public byte[] ExportSampleExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sổ phụ ngân hàng");

            // Tạo tên cột
            worksheet.Cells[1, 1].Value = "Ngân hàng: ";
            worksheet.Cells[2, 1].Value = "Số tài khoản (*)";
            worksheet.Cells[4, 1].Value = "Ngày (*)";
            worksheet.Cells[4, 2].Value = "Diễn Giải (*)";
            worksheet.Cells[4, 3].Value = "Phát sinh nợ (*)";
            worksheet.Cells[4, 4].Value = "Phát sinh có (*)";
            worksheet.Cells[4, 5].Value = "Tài khoản đối ứng (*)";
            worksheet.Cells[4, 6].Value = "Mã khách hàng (*)";

            // Thiết lập độ rộng cột
            worksheet.Column(1).Width = 25;
            worksheet.Column(2).Width = 50;
            worksheet.Column(3).Width = 25;
            worksheet.Column(4).Width = 25;
            worksheet.Column(5).Width = 25;
            worksheet.Column(6).Width = 25;
            worksheet.Column(7).Width = 25;
            using (var range = worksheet.Cells[4, 1, 4, 7])
            {
                range.Style.Font.Bold = true;
                //range.Style.Fill.PatternType = ExcelFillStyle.Solid; //set Pattern
                //range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray); // Set color
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            return package.GetAsByteArray();
        }

        public async Task<SoPhuNganHangDto> ImportAysnc()
        {
            try
            {
                var soPhuSupports = await _soPhuSupportRepository.GetListAsync();
                var path = Path.Combine(AppContext.BaseDirectory, "TemporarySoPhuNganHang");
                var existingFiles = Directory.GetFiles(path);// Lấy ra file có trong thư mục có đường dẫn path
                if (existingFiles.Any())
                {
                    var filePath = existingFiles[0];
                    FileInfo fileInfo = new FileInfo(filePath);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (FileStream file = new FileStream(fileInfo.ToString(), FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook? workbook;
                        if (Path.GetExtension(fileInfo.ToString()).ToLower() == ".xls")
                        { 
                            workbook = new HSSFWorkbook(file); // Sử dụng HSSFWorkbook cho định dạng .xls
                        }
                        else if (Path.GetExtension(fileInfo.ToString()).ToLower() == ".xlsx")
                        {
                            workbook = new XSSFWorkbook(file); // Sử dụng XSSFWorkbook cho định dạng .xlsx
                        }
                        else
                            workbook = null;
                        var result= new SoPhuNganHangDto();
                        if (workbook != null)
                        {
                            ISheet worksheet = workbook.GetSheetAt(0); // Lấy sheet đầu tiên

                            //vị trí của các cột cần lấy
                            int ngay = -1;
                            int ghiNo = -1;
                            int ghiCo = -1;
                            int dienGiai = -1;
                            int rowIndex = -1;

                            int totalColumn = 0;
                            int totalRow = worksheet.LastRowNum + 1; // Lấy số lượng dòng
                            bool found = false;
                            //Lấy số lượng cột của dòng có chứa nhiều cột nhất
                            for (int i = worksheet.FirstRowNum; i <= totalRow; i++)
                            {
                                IRow row = worksheet.GetRow(i);
                                if(row != null)
                                {
                                    int currentColumns = row.LastCellNum + 1;
                                    if (currentColumns > totalColumn)
                                    {
                                        totalColumn = currentColumns;
                                    }
                                }
                            }
                            // Tìm vị trí của các cột
                            for (int i = worksheet.FirstRowNum; i < totalRow && !found; i++)
                            {
                                IRow row = worksheet.GetRow(i);
                                if (row != null)
                                {
                                    // Kiểm tra với mảng soPhuSupports
                                    foreach (var item in soPhuSupports)
                                    {
                                        for (int j = row.FirstCellNum; j < totalColumn && !found; j++)
                                        {
                                            var data = row.GetCell(j)?.ToString()?.Replace("\n", "");
                                            if (data != null)
                                            {

                                                if (item.TenSoTaiKhoan != null && data.Contains(item.TenSoTaiKhoan))
                                                {
                                                    //lấy thông tin của so tai khoan
                                                    Regex regex = new Regex(@"\d+");
                                                    Match match = regex.Match(data);
                                                    if (match.Value != null && match.Value != "")
                                                        result.SoTaiKhoan = match.Value;
                                                    else
                                                    {
                                                        for (int k = j; k < row.Cells.Count; k++)
                                                        {
                                                            Regex numericRegex = new Regex(@"^\d+$");
                                                            string? stk = row.Cells[k].ToString();
                                                            if (numericRegex.IsMatch(stk ?? ""))
                                                            {
                                                                result.SoTaiKhoan = stk ?? "";
                                                                break;
                                                            }
                                                        }
                                                    }

                                                }
                                                if (item.TenNgay == data)
                                                    ngay = j;
                                                if (item.TenGhiNo == data)
                                                    ghiNo = j;
                                                if (item.TenGhiCo == data)
                                                    ghiCo = j;
                                                if (item.TenDienGiai == data)
                                                    dienGiai = j;
                                                if (ngay >= 0 && ghiNo >= 0 && ghiCo >= 0 && dienGiai >= 0)
                                                {
                                                    result.TenNganHang = item.TenNganHang;
                                                    rowIndex = i;
                                                    found = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            // Tạo danh sách items
                            var items = new List<DataSoPhu>();
                            try
                            {
                                int id = 1;
                                for (int i = rowIndex + 1; i < totalRow && rowIndex >= 0; i++)
                                {
                                    IRow row = worksheet.GetRow(i);
                                    if (row != null)
                                    {
                                        var item = new DataSoPhu();                                       
                                        string? ngayData = string.Empty;
                                        var Length = row.GetCell(ngay)?.ToString()?.Length;

                                        //xử lý trường hợp dữ liệu trong file excel không được thêm đấy nháy <'> đầu câu
                                        if (Length == 13)                                       
                                            ngayData = row.GetCell(ngay)?.ToString()?.Replace("thg", "").Replace("-", "/").Replace(" ", "0");                                       
                                        else if (Length == 14)                                        
                                            ngayData = row.GetCell(ngay)?.ToString()?.Replace("thg", "").Replace("-", "/").Replace(" ", "");                                       
                                        else                                       
                                            ngayData = row.GetCell(ngay)?.ToString()?.Replace("-", "/");
                                        

                                        if (DateTime.TryParseExact(ngayData, ngayData?.Length == 10 ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                                        {
                                            item.Id = id++;
                                            item.Ngay = date;
                                            if (decimal.TryParse(row.GetCell(ghiCo)?.ToString()?.Replace(",", "").Replace("-", "") ?? "0", out decimal psCoVND))
                                                item.PsCoVND = psCoVND;
                                            if (decimal.TryParse(row.GetCell(ghiNo)?.ToString()?.Replace(",", "").Replace("+", "") ?? "0", out decimal psNoVND))
                                                item.PsNoVND = psNoVND;
                                            item.DienGiai = row.GetCell(dienGiai)?.ToString();
                                            if (item.PsCoVND > 0)
                                                item.Loai = SystemConstants.LoaiPhieu.GiayBaoCo;
                                            else if (item.PsNoVND > 0)
                                                item.Loai = SystemConstants.LoaiPhieu.GiayBaoNo;
                                            else
                                                item.Loai = SystemConstants.NA;
                                            if (result.TenNganHang == "Samples")
                                            {
                                                string? tkud = row.GetCell(5)?.ToString();
                                                if(tkud != null && await _taiKhoanRepository.AnyAsync(x => x.TaiKhoanUd == tkud))
                                                {
                                                    var tk = await _taiKhoanRepository.GetAsync(x => x.TaiKhoanUd == tkud);
                                                    item.TkDu = tk?.Id;
                                                    item.TkDuUd = tk?.TaiKhoanUd;
                                                }
                                                string? khud = row.GetCell(6)?.ToString();
                                                if (khud != null && await _khachHangRepository.AnyAsync(x => x.KhachHangUd == khud))
                                                {
                                                    var kh = await _khachHangRepository.GetAsync(x => x.KhachHangUd == khud);
                                                    item.KhachHangId = kh?.Id;
                                                    item.KhachHangUd = kh?.KhachHangUd;
                                                    item.KhachHangNm = kh?.KhachHangNm;
                                                }
                                            }
                                            items.Add(item);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                            result.DataSoPhus = items;

                        }
                        // Trả về danh sách items
                        return result;

                    }
                }
                return new SoPhuNganHangDto();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex?.ToString());
                return new SoPhuNganHangDto();
            }
            
        }
    }
}
