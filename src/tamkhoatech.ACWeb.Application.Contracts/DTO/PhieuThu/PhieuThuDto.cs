using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuThuDto : EntityDto<int?>
    {
        public string? LoaiPhieu { get; set; }
        public int? ChiNhanhId { get; set; }
        public string? ChiNhanhNm { get; set; }
        public int? GiaoDichId { get; set; }
        public string? GiaoDichUd { get; set; }
        public string? GiaoDichNm { get; set; }
        public int? KhachHangId { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public decimal? SoDu { get; set; }
        public string? NguoiNop { get; set; }
        public string? DienGiai { get; set; }
        public int? GhiNoTkId { get; set; }
        public string? GhiNoTkUd { get; set; }
        public string? GhiNoTkNm { get; set; }
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoPhieu { get; set; }
        public string? QuyenSoId { get; set; }
        public string? ChungTu { get; set; }
        public int? NgoaiTeId { get; set; }
        public string? NgoaiTeUd { get; set; }
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
        public List<PhieuThuCTDto>? PhieuThuCTDtos { get; set; }
        public List<SoCaiDto>? SoCaiDtos { get; set; }
    }
}
