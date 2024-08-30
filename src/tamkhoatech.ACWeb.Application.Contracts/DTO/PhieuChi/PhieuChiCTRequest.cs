using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuChiCTRequest
    {
        public int? Stt { get; set; }
        public int? HoaDonDichVuId { get; set; }
        public int? HoaDonChiId { get; set; }
        public string? SoCt { get; set; }
        public DateTime? NgayHd { get; set; }
        public int? NgoaiTeId { get; set; }
        public string? NgoaiTeUd { get; set; }
        public decimal? TyGia { get; set; }
        public int? GhiNoTk { get; set; }
        public string? GhiNoTkUd { get; set; }
        public string? GhiNoTkNm { get; set; }
        public int? KhachHangId { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public decimal? TienTrenHd { get; set; }
        public decimal? TienTrenHdVND { get; set; }
        public decimal? DaTt { get; set; }
        public decimal? DaTtVND { get; set; }
        public decimal? ConPhaiTt { get; set; }
        public decimal? ConPhaiTtVND { get; set; }
        public decimal? PsNo { get; set; }
        public decimal? PsNoVND { get; set; }
        public int? LoaiThue { get; set; }
        public string? LoaiThueUd { get; set; }
        public int? MaThue { get; set; }
        public string? MaThueUd { get; set; }
        public decimal? ThueSuat { get; set; }
        public decimal? Thue { get; set; }
        public decimal? ThueVND { get; set; }
        public decimal? ThanhToan { get; set; }
        public decimal? ThanhToanVND { get; set; }
        public decimal? ThanhToanQd { get; set; }
        public decimal? TyGiaGS { get; set; }
        public string? DienGiai { get; set; }
        public string? DienGiai2 { get; set; }
        public decimal? TienHt { get; set; }
        public string? SoHd { get; set; }
        public string? SoSeri { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? VuViecId { get; set; }
        public string? VuViecUd { get; set; }
        public int? MaPhiId { get; set; }
        public string? MaPhiUd { get; set; }
        public int? BoPhanHTId { get; set; }
        public string? BoPhanHTUd { get; set; }
        public int? VatTuId1 { get; set; }
        public string? VatTuUd1 { get; set; }
        public int? MaTD01 { get; set; }
        public string? MaTD01Ud { get; set; }
        public DateTime? NgayTD01 { get; set; }
        public decimal? SoLuongTD01 { get; set; }
        public string? GhiChuTD01 { get; set; }
        public int? MaTD02 { get; set; }
        public string? MaTD02Ud { get; set; }
        public DateTime? NgayTD02 { get; set; }
        public decimal? SoLuongTD02 { get; set; }
        public string? GhiChuTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public string? MaTD03Ud { get; set; }
        public DateTime? NgayTD03 { get; set; }
        public decimal? SoLuongTD03 { get; set; }
        public string? GhiChuTD03 { get; set; }
        public int? MauHDId { get; set; }
        public string? MauHDUd { get; set; }
        public string? KiHieuMauHD { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }
        public string? DieuChinhThueTNDNUd { get; set; }
    }
    public class PhieuChiCt01Request : PhieuChiCTRequest
    {
        [NullAttribute]
        public new string? SoHd { get; set; }
    }
    public class PhieuChiCt02Request : PhieuChiCTRequest
    {
        [NullAttribute]
        public new int? GhiNoTk { get; set; }
    }
    public class PhieuChiCt03Request : PhieuChiCTRequest
    {
        [NullAttribute]
        public new int? GhiNoTk { get; set; }
        [NullAttribute]
        public new int? KhachHangId { get; set; }
        [NullAttribute]
        public new int? LoaiThue { get; set; }
    }
    public class PhieuChiCt04Request : PhieuChiCTRequest
    {
        [NullAttribute]
        public new int? GhiNoTk { get; set; }
        [NullAttribute]
        public new int? LoaiThue { get; set; }
    }
}
