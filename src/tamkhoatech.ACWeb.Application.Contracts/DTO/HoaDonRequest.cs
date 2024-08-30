using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class HoaDonRequest
    {
        public int? Stt { set; get; }
        public int? PhieuNhapId { get; set; }
        public int? PhieuXuatId { get; set; }
        public int? PhieuChiId { get; set; }
        public int? PhieuKeToanId { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? MauBC { get; set; }
        [NullAttribute]
        public int? LoaiThue { get; set; }
        public string? LoaiThueUd { get; set; }
        public string? MaCt { get; set; }
        public DateTime? NgayCt { get; set; }
        public string? SoCt { get; set; }
        [NullAttribute]
        public DateTime? NgayCt0 { get; set; }
        [NullAttribute]
        public string? SoCt0 { get; set; }
        public string? SoSeri0 { get; set; }
        [NullAttribute]
        public int? KhachHangId { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public int? KhoId { get; set; }
        public int? VuViecId { get; set; }
        public string? VuViecUd { get; set; }
        public string? VatTu { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiaVND { get; set; }
        public decimal? Tien { get; set; }
        public decimal? TienVND { get; set; }
        public decimal? Thue { get; set; }
        public decimal? ThueVND { get; set; }
        public int? MaThue { get; set; }
        public string? MaThueUd { get; set; }
        public decimal? ThueSuat { get; set; }
        [NullAttribute]
        public int? TkThue { get; set; }
        public string? TkThueUd { get; set; }
        public int? TkDu { get; set; }
        public string? TkDuUd { get; set; }
        public string? CucThue { get; set; }
        public string? GhiChu { get; set; }
        public int? MaTuDo { get; set; }
        public int? MaPhiId { get; set; }
        public string? MaPhiUd { get; set; }
        public int? MaTD01 { get; set; }
        public string? MaTD01Ud { get; set; }
        public string? MaTD02Ud { get; set; }
        public string? MaTD03Ud { get; set; }
        public int? MaTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public bool? IsPhieu { get; set; }
        public int? MauHDId { get; set; }
        public string? MauHDUd { get; set; }
        public string? KyHieuMauHD { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }
    }
}
