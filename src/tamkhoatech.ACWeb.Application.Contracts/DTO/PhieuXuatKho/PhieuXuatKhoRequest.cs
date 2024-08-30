using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatKhoRequest
    {
        public string? LoaiPhieu { set; get; }
        [Required]
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhNm { set; get; }
        [Required]
        public int? GiaoDichId { set; get; }
        public string? GiaoDichNm { set; get; }
        [Required]
        public int? KhachHangId { set; get; }
        public string? KhachHangNm { set; get; }
        public string? DiaChi { set; get; }
        public string? NgNhanHang { set; get; }
        public string? DienGiai { set; get; }
        public string? SoCt { set; get; }
        public string? QuyenSo { set; get; }
        [Required]
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayLap { set; get; }
        [Required]
        public int? NgoaiTeId { set; get; }
        public decimal? TyGia { set; get; }
        public bool? IsXuatGiaDd { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? TongTien { set; get; }
        public decimal? TongTienVND { set; get; }
        public int? RefId { set; get; }
        public bool? IsSuaTien { set; get; }
        public bool? IsPostSC { set; get; }
        public int? PhieuXuatId { set; get; }
        public int? PhieuNhapKhoId { set; get; }
        public int? PhieuDieuChinhKhoId { set; get; }
        public int? LenhSanXuatId { set; get; }
        public List<PhieuXuatKhoCtRequest>? PhieuXuatKhoCtRequests { get; set; }
        public List<SoCaiRequest>? SoCaiRequests { get; set; }
    }
}
