using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuChiRequest
    {
        public string? LoaiPhieu { get; set; }
        [Required]
        public int? ChiNhanhId { get; set; }
        [Required]
        public int? GiaoDichId { get; set; }
        public string? GiaoDichUd { get; set; }
        [Required]
        public int? KhachHangId { get; set; }
        public int? KhachHangNA { get; set; }
        public string? KhachHangUd { get; set; }
        public string? NguoiNhan { get; set; }
        public string? DienGiai { get; set; }
        [Required]
        public int? GhiNoTkId { get; set; }
        public string? GhiNoTkNm { get; set; }
        [Required]
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoPhieu { get; set; }
        [Required]
        public string? QuyenSoId { get; set; }
        public string? ChungTu { get; set; }
        [Required]
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TyGiaGS { get; set; }
        [Required]
        public int? HoaDonGTGT { get; set; }
        public int? TkThue { get; set; }
        public string? TkThueUd { get; set; }
        public decimal? Tien { get; set; }
        public decimal? TienVND { get; set; }
        public decimal? TienThue { get; set; }
        public decimal? TienThueVND { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public string? TenNganHang { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? TenTinhThanh { get; set; }
        public string? TenKhachHang { get; set; }
        public string? DiaChi { get; set; }
        public string? SoTaiKhoan2 { get; set; }
        public string? TenNganHang2 { get; set; }
        public string? DiaChi2 { get; set; }
        public string? NoiDung { get; set; }
        public string? CamKet { get; set; }
        public int? MucDich { get; set; }
        public int? HinhThuc { get; set; }
        public int? PhiTrong { get; set; }
        public int? PhiNgoai { get; set; }
        public string? MaSoThue { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsTaoTuDong { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuNhapId { get; set; }
        public string? PhieuNhapUd { get; set; }
        public List<PhieuChiCTRequest>? PhieuChiCTRequests { get; set; }
        public List<HoaDonRequest>? HoaDonRequests { get; set; }
        public List<SoCaiRequest>? SoCaiRequests { get; set; }
        public decimal? SoDu { get; set; }
        public string? ChiNhanhNm { get; set; }
        public string? GiaoDichNm { get; set; }
        public string? BankAccountNumber { get; set; }
    }
}
