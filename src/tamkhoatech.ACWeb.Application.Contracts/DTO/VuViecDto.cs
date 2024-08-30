using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class VuViecDto : EntityDto<int?>
    {
        public string? VuViecUd { get; set; }
        public string? VuViecNm { get; set; }
        public string? VuViecNm2 { get; set; }
        public int? KhachHangId { get; set; }
        public int? BPKDId { get; set; }
        public int? BPTHId { get; set; }
        public DateTime? NgayBd { get; set; }
        public DateTime? NgayKt { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? GiaTriHd { get; set; }
        public decimal? TienVND { get; set; }
        public int? NhomVuViec1 { get; set; }
        public int? NhomVuViec2 { get; set; }
        public int? NhomVuViec3 { get; set; }
        public string? GhiChu { get; set; }
        public string? SoHd { get; set; }
        public DateTime? NgayHd { get; set; }
        public string? NoiDung { get; set; }
        public string? ThoiGianKhoiCong { get; set; }
        public DateTime? NgayBBBG { get; set; }
        public DateTime? NgayTLHD { get; set; }
        public string? MaTd1 { get; set; }
        public DateTime? NgayTd1 { get; set; }
        public decimal? SoLuongTd1 { get; set; }
        public string? GhiChuTd1 { get; set; }
        public string? MaTd2 { get; set; }
        public DateTime? NgayTd2 { get; set; }
        public decimal? SoLuongTd2 { get; set; }
        public string? GhiChuTd2 { get; set; }
        public string? MaTd3 { get; set; }
        public DateTime? NgayTd3 { get; set; }
        public decimal? SoLuongTd3 { get; set; }
        public string? GhiChuTd3 { get; set; }
        public int? LoaiChiPhi { get; set; }
    }
}
