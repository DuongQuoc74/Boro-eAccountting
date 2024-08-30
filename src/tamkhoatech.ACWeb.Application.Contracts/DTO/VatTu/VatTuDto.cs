using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class VatTuDto : EntityDto<int?>
    {
        public string? VatTuUd { get; set; }
        public string? VatTuNm { get; set; }
        public string? VatTuNm2 { get; set; }
        public string? DonViTinh { get; set; }
        public string? SoQD31 { get; set; }
        public string? SoDangKy { get; set; }
        public string? HamLuong { get; set; }
        public string? CachDung { get; set; }
        public string? HangSX { get; set; }
        public string? NuocSX { get; set; }
        public int? NhaThau { get; set; }
        public bool? IsTheoDoiTonKho { get; set; }
        public int? CachTinhGia { get; set; }
        public int? LoaiVatTu { get; set; }
        public string? LoaiVatTuNm { get; set; }
        public int? TkKho { get; set; }
        public string? TkKhoUd { get; set; }
        public string? TkKhoNm { get; set; }
        public bool? IsSuaTkKho { get; set; }
        public int? TkGiaVon { get; set; }
        public string? TkGiaVonUd { get; set; }
        public string? TkGiaVonNm { get; set; }
        public int? TkCongNo { get; set; }
        public int? TkDoanhThu { get; set; }
        public string? TkDoanhThuUd { get; set; }
        public string? TkDoanhThuNm { get; set; }
        public int? TkHangBiTra { get; set; }
        public string? TkHangBiTraUd { get; set; }
        public string? TkHangBiTraNm { get; set; }
        public int? TkSpDoDang { get; set; }
        public string? TkSpDoDangUd { get; set; }
        public string? TkSpDoDangNm { get; set; }
        public int? TkChenhLechGiaVt { get; set; }
        public string? TkChenhLechGiaVtUd { get; set; }
        public string? TkChenhLechGiaVtNm { get; set; }
        public int? NhomVT1 { get; set; }
        public string? NhomVtNm1 { get; set; }
        public int? NhomVT2 { get; set; }
        public string? NhomVtNm2 { get; set; }
        public int? NhomVT3 { get; set; }
        public string? NhomVtNm3 { get; set; }
        public decimal? SLTonToiThieu { get; set; }
        public decimal? SLTonToiDa { get; set; }
        public decimal? TyLeDT { get; set; }
        public bool? IsTinhLuong { get; set; }
        public string? GhiChu { get; set; }
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
        public int? KhoId { get; set; }
        public string? KhoNm { get; set; }
        public bool? IsKhongTinChiPhiNhanCong { get; set; }
        public bool? IsKhongTinhChiPhiChung { get; set; }
    }
}
