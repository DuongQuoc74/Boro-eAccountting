using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuKeToanDto : EntityDto<int?>
    {
        public string? LoaiPhieu { set; get; }
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhNm { set; get; }
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayCt { set; get; }
        public string? SoCt { set; get; }
        public string? DienGiai { set; get; }
        public string? QuyenSo { set; get; }
        public int? NgoaiTeId { set; get; }
        public string? NgoaiTeUd { set; get; }
        public decimal? TyGia { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public int? RefId { get; set; }
        public bool? IsSuaTien { set; get; }
        public bool? IsPostSC { set; get; }
        public bool? IsNghiemThu { set; get; }
        public List<PhieuKeToanCtDto>? PhieuKeToanCtDtos { get; set; }
        public List<HoaDonGtgtDto>? HoaDonGtgtDtos { get; set; }
    }
}
