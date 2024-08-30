using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuNhapKhoRequest
    {
        public string? LoaiPhieu { get; set; }
        [Required]
        public int? ChiNhanhId { get; set; }
        public string? ChiNhanhNm { get; set; }
        [Required]
        public int? GiaoDichId { get; set; }
        public string? GiaoDichNm { get; set; }
        [Required]
        public int? KhachHangId { get; set; }
        public string? KhachHangNm { get; set; }
        public string? DiaChi { get; set; }
        public string? NgGiaoHang { get; set; }
        public string? DienGiai { get; set; }
        [Required]
        public string? SoCt { get; set; }
        public string? QuyenSo { get; set; }
        [Required]
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        [Required]
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public bool? IsNhapGiaTb { get; set; }
        public bool? IsNhapThuHoi { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuXuatId { get; set; }
        public bool? IsTaoPhieuXuatKho { get; set; }
        public int? PhieuDieuChinhKhoId { get; set; }
        [Required]
        public int? KhoXuatNVLId { get; set; }
        public string? KhoXuatNVLUd { get; set; }
        public int? LenhSanXuatId { get; set; }
        public List<PhieuNhapKhoCtRequest>? PhieuNhapKhoCtRequests { get; set; }
        public List<SoCaiRequest>? SoCaiRequests { get; set; }
        public List<TheKhoRequest>? TheKhoRequests { get; set; }
    }
}
