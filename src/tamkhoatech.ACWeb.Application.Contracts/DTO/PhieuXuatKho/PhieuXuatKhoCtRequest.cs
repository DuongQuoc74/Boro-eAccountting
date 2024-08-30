using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatKhoCtRequest
    {
        public int? Id { set; get; }
        public int? PhieuXuatKhoId { set; get; }
        [NullAttribute]
        public int? VatTuId { set; get; }
        public string? VatTuUd { set; get; }
        public string? VatTuNm { set; get; }
        public string? DonViTinh { set; get; }
        [NullAttribute]
        public int? KhoId { set; get; }
        public string? KhoUd { set; get; }
        public DateTime? NgayLo { set; get; }
        public string? SoLo { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? TonKho { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        [NullAttribute]
        public int? GhiCoTk { set; get; }
        public string? GhiCoTkUd { set; get; }
        [NullAttribute]
        public int? GhiNoTk { set; get; }
        public string? GhiNoTkUd { set; get; }
        public int? MaPhiId { set; get; }
        public string? MaPhiUd { set; get; }
        public int? VuViecId { set; get; }
        public string? VuViecUd { set; get; }
        public int? BoPhanHTId { set; get; }
        public string? BoPhanHTUd { set; get; }
        public int? VatTuId1 { set; get; }
        public int? MaTD01 { set; get; }
        public DateTime? NgayTD01 { set; get; }
        public int? SoLuongTD01 { set; get; }
        public string? GhiChuTD01 { set; get; }
        public int? MaTD02 { set; get; }
        public DateTime? NgayTD02 { set; get; }
        public string? SoLuongTD02 { set; get; }
        public string? GhiChuTD02 { set; get; }
        public int? MaTD03 { set; get; }
        public DateTime? NgayTD03 { set; get; }
        public decimal? SoLuongTD03 { set; get; }
        public string? GhiChuTD03 { set; get; }
        public int? DieuChinhThueTNDNId { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
        public string? CongTrinhUd { set; get; }
    }
}
