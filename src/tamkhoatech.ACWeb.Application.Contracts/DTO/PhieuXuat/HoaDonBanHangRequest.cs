using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public  class HoaDonBanHangRequest
    {
        public int? Stt { set; get; }
        public int? PhieuXuatId { set; get; }
        public int? KhachHangId { set; get; }
        [NullAttribute]
        public int? TkDoanhThu { set; get; }
        public string? TkDoanhThuUd { set; get; }
        public string? TkDoanhThuNm { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public string? NhomDk { set; get; }
        [NullAttribute]
        public int? ThueSuatId { set; get; }
        public string? ThueSuatUd { set; get; }
        public decimal? ThueSuat { set; get; }
        public decimal? Thue { set; get; }
        public decimal? ThueVND { set; get; }
        [NullAttribute]
        public int? TkThue { set; get; }
        public string? TkThueUd { set; get; }
        public string? DienGiai { set; get; }
        public int? MaPhiId { set; get; }
        public string? MaPhiUd { set; get; }
        public int? VuViecId { set; get; }
        public string? VuViecUd { set; get; }
        public int? BoPhanHTId { set; get; }
        public int? VatTuId1 { set; get; }
        public int? MaTD01 { set; get; }
        public DateTime? NgayTD01 { set; get; }
        public decimal? SoLuongTD01 { set; get; }
        public string? GhiChuTD01 { set; get; }
        public int? MaTD02 { set; get; }
        public DateTime? NgayTD02 { set; get; }
        public decimal? SoLuongTD02 { set; get; }
        public string? GhiChuTD02 { set; get; }
        public int? MaTD03 { set; get; }
        public DateTime? NgayTD03 { set; get; }
        public decimal? SoLuongTD03 { set; get; }
        public string? GhiChuTD03 { set; get; }
        public string? DonViTinh { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public bool? EInvoice { set; get; }
        public string? ECreatedBy { set; get; }
        public DateTime? ECreatedDate { set; get; }
        public DateTime? EModifiedDate { set; get; }
        public int? DieuChinhThueTNDNId { set; get; }
        public string? ConnectAEDichVu { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
        public string? CongTrinhUd { set; get; }
    }
}
