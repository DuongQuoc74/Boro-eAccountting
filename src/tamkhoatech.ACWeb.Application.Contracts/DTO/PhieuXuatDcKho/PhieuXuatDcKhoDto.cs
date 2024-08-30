using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatDcKhoDto : EntityDto<int?>
    {
        public string? LoaiPhieu { set; get; }
        public int? ChiNhanhId { set; get; }
        public int? KhoXuatId { set; get; }
        public string? KhoXuatUd { set; get; }
        public int? KhoNhapId { set; get; }
        public string? KhoNhapUd { set; get; }
        public int? VuViecXuatId { set; get; }
        public int? VuViecNhapId { set; get; }
        public string? NgNhanHang { set; get; }
        public string? DienGiai { set; get; }
        public string? SoCt { set; get; }
        public string? QuyenSo { set; get; }
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayLap { set; get; }
        public int? NgoaiTeId { set; get; }
        public string? NgoaiTeUd { set; get; }
        public decimal? TyGia { set; get; }
        public bool? IsXuatGiaDd { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? TongTien { set; get; }
        public decimal? TongTienVND { set; get; }
        public bool? IsSuaTien { set; get; }
        public bool? IsPostSC { set; get; }
        public bool? IsBoTinhGia { set; get; }
        public List<PhieuXuatDcKhoCtDto>? PhieuXuatDcKhoCtDtos { set; get; }

    }
}
