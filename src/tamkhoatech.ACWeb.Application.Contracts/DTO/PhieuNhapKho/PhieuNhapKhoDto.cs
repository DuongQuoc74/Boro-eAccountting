using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuNhapKhoDto : EntityDto<int?>
    {
        public string? LoaiPhieu { get; set; }
        public int? ChiNhanhId { get; set; }
        public string? ChiNhanhNm { get; set; }
        public int? GiaoDichId { get; set; }
        public string? GiaoDichNm { get; set; }
        public int? KhachHangId { get; set; }
        public string? NgGiaoHang { get; set; }
        public string? DienGiai { get; set; }
        public string? SoCt { get; set; }
        public string? QuyenSo { get; set; }
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
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
        public int? KhoXuatNVLId { get; set; }
        public int? LenhSanXuatId { get; set; }
        public List<PhieuNhapKhoCtDto>? PhieuNhapKhoCtDtos { get; set; }
        public List<SoCaiDto>? SoCaiDtos { get; set; }
        public List<TheKhoDto>? TheKhoDtos { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public string? DiaChi { get; set; }
        public string? NgoaiTeUd { get; set; }
    }
}
