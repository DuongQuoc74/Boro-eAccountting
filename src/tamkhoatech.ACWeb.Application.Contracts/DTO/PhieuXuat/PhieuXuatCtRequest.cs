using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatCtRequest
    {
        public int? Stt { set; get; }
        public int? PhieuXuatId { set; get; }
        [NullAttribute]
        public int? VatTuId { set; get; }
        public string? VatTuUd { set; get; }
        public string? VatTuNm { set; get; }
        public string? DonViTinh { set; get; }
        [NullAttribute]
        public int? KhoId { set; get; }
        public string? KhoUd { set; get; }
        public int? DiaDiemId { set; get; }
        public DateTime? NgayLo { set; get; }
        public string? SoLo { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? SoLuongChon { set; get; }
        public decimal? TonKho { set; get; }
        public decimal? GiaSauThue { set; get; }
        public decimal? GiaSauThueVND { set; get; }
        public decimal? TienSauThue { set; get; }
        public decimal? TienSauThueVND { set; get; }
        public decimal? GiaVon { set; get; }
        public decimal? GiaVonVND { set; get; }
        public decimal? TienVon { set; get; }
        public decimal? TienVonVND { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public int? TkDoanhThu { set; get; }
        public string? TkDoanhThuUd { set; get; }
        public int? TkKho { set; get; }
        public string? TkKhoUd { set; get; }
        public int? TkGiaVon { set; get; }
        public string? TkGiaVonUd { set; get; }
        public decimal? TyLeCk { set; get; }
        public decimal? TienCk { set; get; }
        public decimal? TienCkVND { set; get; }
        public int? TkChietKhau { set; get; }
        public string? TkChietKhauUd { set; get; }
        public int? GhiCoTk { set; get; }
        public bool? IsNhapTraLai { set; get; }
        public int? PhieuNhapChiTietId { set; get; }
        public int? PhieuChonCtId { set; get; }
        public int? MaPhiId { set; get; }
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
        public string? VatTuNm3 { set; get; }
        public int? DieuChinhThueTNDNId { set; get; }
        public string? ConnectAEVatTu { set; get; }
        [NullAttribute]
        public int? ThueSuatId { set; get; }
        public string? ThueSuatUd { set; get; }
        public decimal? ThueSuat { set; get; }
        public decimal? Thue { set; get; }
        public decimal? ThueVND { set; get; }
        [NullAttribute]
        public int? TkThue { set; get; }
        public string? TkThueUd { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
    }
}
