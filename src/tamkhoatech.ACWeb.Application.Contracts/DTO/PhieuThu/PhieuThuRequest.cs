using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuThuRequest
    {
        public string? LoaiPhieu { get; set; }

        [Required]
        public int? ChiNhanhId { get; set; }
        public string? ChiNhanhNm { get; set; }
        [Required]
        public int? GiaoDichId { get; set; }
        public string? GiaoDichNm { get; set; }
        public string? GiaoDichUd { get; set; }
        [Required]
        public int? KhachHangId { get; set; }
        public string? KhachHangNm { get; set; }
        public decimal? SoDu { get; set; }
        public string? NguoiNop { get; set; }
        public string? DienGiai { get; set; }
        [Required]
        public int? GhiNoTkId { get; set; }
        public string? GhiNoTkNm { get; set; }
        [Required]
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoPhieu { get; set; }
        public string? QuyenSoId { get; set; }
        public string? ChungTu { get; set; }
        [Required]
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsTaoTuDong { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuXuatId { get; set; }
        public string? PhieuXuatUd { get; set; }
        public string? BankAccountNumber { get; set; }

        public List<PhieuThuCTRequest>? PhieuThuCTRequests { get; set; }
        public List<SoCaiRequest>? SoCaiRequests { get; set; }
    }
}
