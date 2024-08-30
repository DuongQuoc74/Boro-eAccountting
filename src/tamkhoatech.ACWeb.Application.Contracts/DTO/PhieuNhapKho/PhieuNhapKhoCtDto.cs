using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuNhapKhoCtDto : EntityDto<int?>
    {
        public int? PhieuNhapKhoId { get; set; }
        public int? VatTuId { get; set; }
        public int? KhoId { get; set; }
        public DateTime? NgayLo { get; set; }
        public string? SoLo { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? TonKho { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiaVND { get; set; }
        public decimal? Tien { get; set; }
        public decimal? TienVND { get; set; }
        public int? GhiNoTK { get; set; }
        public int? GhiCoTK { get; set; }
        public int? MaPhiId { get; set; }
        public int? VuViecId { get; set; }
        public int? BoPhanHTId { get; set; }
        public int? VatTuId1 { get; set; }
        public int? MaTD01 { get; set; }
        public DateTime? NgayTD01 { get; set; }
        public decimal? SoLuongTD01 { get; set; }
        public string? GhiChuTD01 { get; set; }
        public int? MaTD02 { get; set; }
        public DateTime? NgayTD02 { get; set; }
        public decimal? SoLuongTD02 { get; set; }
        public string? GhiChuTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public DateTime? NgayTD03 { get; set; }
        public decimal? SoLuongTD03 { get; set; }
        public string? GhiChuTD03 { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }
        public PhieuNhapKhoDto? PhieuNhapKho { get; set; }
        public string? VatTuUd { get; set; }
        public string? VatTuNm { get; set; }
        public string? KhoUd { get; set; }
        public string? DonViTinh { get; set; }
        public string? GhiNoTkUd { get; set; }
        public string? GhiCoTkUd { get; set; }
    }
}
