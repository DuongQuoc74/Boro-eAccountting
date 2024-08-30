using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class SoPhuNganHangDto
    {
        public string? TenNganHang { get; set; }
        public string? SoTaiKhoan {  get; set; }
        public string? TaiKhoanNganHang {  get; set; }
        public List<DataSoPhu>? DataSoPhus { get; set; }

    }

    public class DataSoPhu
    {
        public int? Id { get; set; }
        public string? Loai { get; set; }
        public DateTime? Ngay { get; set; }
        public string? DienGiai { get; set; }
        public decimal? PsNoVND { get; set; }
        public decimal? PsCoVND { get; set; }
        public int? Tk { get; set; }
        public string? TkUd { get; set; }
        [NullAttribute]
        public int? TkDu { get; set; }
        public string? TkDuUd { get; set; }
        [NullAttribute]
        public int? KhachHangId { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public string? MaSoThue { get; set; }
        public string? DiaChi { get; set; }
    }
}
