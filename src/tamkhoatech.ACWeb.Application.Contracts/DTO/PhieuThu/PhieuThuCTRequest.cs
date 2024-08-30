using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuThuCTRequest
    {

        public int? Stt { get; set; }
        public int? HoaDonDichVuId { get; set; }
        public int? HoaDonThuId { get; set; }
        public string? SoCt { get; set; }
        public string? DienGiai { get; set; }
        public string? DienGiai2 { get; set; }
        public string? SoHd { get; set; }
        public string? SoSeri { get; set; }
        public string? GhiChuTD01 { get; set; }
        public DateTime? NgayHd { get; set; }
        public DateTime? NgayLap { get; set; }
        public DateTime? NgayTD01 { get; set; }
        public int? NgoaiTeId { get; set; }
        public string? NgoaiTeUd { get; set; }
        public int? MaTD02 { get; set; }
        public DateTime? NgayTD02 { get; set; }
        public DateTime? NgayTD03 { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TienTrenHd { get; set; }
        public decimal? DaTt { get; set; }
        public decimal? ConPhaiTt { get; set; }
        public decimal? PsCo { get; set; }
        public decimal? PsCoVND { get; set; }
        public decimal? ThanhToan { get; set; }
        public decimal? ThanhToanVND { get; set; }
        public decimal? ThanhToanQd { get; set; }
        public decimal? TyGiaGS { get; set; }
        public decimal? TienHt { get; set; }
        public decimal? SoLuongTD01 { get; set; }
        public decimal? SoLuongTD02 { get; set; }
        public decimal? SoLuongTD03 { get; set; }
        public string? GhiChuTD02 { get; set; }
        public string? GhiChuTD03 { get; set; }
        public int? GhiCoTk { get; set; }
        public string? GhiCoTkUd { get; set; }
        public string? GhiCoTkNm { get; set; }
        public int? KhachHangId { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public int? VuViecId { get; set; }
        public int? MaPhiId { get; set; }
        public int? BoPhanHTId { get; set; }
        public int? VatTuId1 { get; set; }
        public int? MaTD01 { get; set; }
        public int? MaTD03 { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }
    }
    public class PhieuThuCt01Request : PhieuThuCTRequest
    {
        [NullAttribute]
        public new string? SoHd { get; set; }
    }
    public class PhieuThuCt02Request : PhieuThuCTRequest
    {
        [NullAttribute]
        public new int? GhiCoTk { get; set; }
    }
    public class PhieuThuCt03Request : PhieuThuCTRequest
    {
        [NullAttribute]
        public new int? GhiCoTk { get; set; }
        [NullAttribute]
        public new int? KhachHangId { get; set; }
    }
    public class PhieuThuCt04Request : PhieuThuCTRequest
    {
        [NullAttribute]
        public new int? GhiCoTk { get; set; }
    }
}
