using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuNhapCtRequest
    {
        public int? PhieuNhapId { set; get; }
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
        public decimal? TonKho { set; get; }
        public decimal? SoLuongBuy { set; get; }
        public decimal? SoLuongPlus { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? SoLuongConLai { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? TienTt { set; get; }
        public decimal? TienTtVND { set; get; }
        public decimal? GiaVon { set; get; }
        public decimal? GiaVonVND { set; get; }
        public decimal? TienVon { set; get; }
        public decimal? TienVonVND { set; get; }
        public decimal? ChiPhi { set; get; }
        public decimal? ChiPhiVND { set; get; }
        public decimal? ThueNk { set; get; }
        public decimal? ThueNkVND { set; get; }
        public decimal? TyLeCk { set; get; }
        public decimal? ChietKhau { set; get; }
        public decimal? ChietKhauVND { set; get; }
        public int? TkHbtl { set; get; }
        public int? TkKho { set; get; }
        public int? TkGiaVon { set; get; }
        public int? TkChietKhau { set; get; }
        [NullAttribute]
        public int? GhiNoTK { set; get; }
        public string? GhiNoTKUd { set; get; }
        public bool? IsXuatTraLai { set; get; }
        public int? PhieuXuatChiTietId { set; get; }
        public int? MaPhiId { set; get; }
        public string? MaPhiUd { set; get; }
        public int? VuViecId { set; get; }
        public string? VuViecUd { set; get; }
        public int? BoPhanHTId { set; get; }
        public int? VatTuId1 { set; get; }

        public int? MaTD01 { set; get; }
        public string? MaTD01Ud { set; get; }
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
        public int? DieuChinhThueTNDNId { set; get; }
        public string? ConnectAEVatTu { set; get; }
        public bool? IsSuaTkKho { set; get; }
        public int? Stt { set; get; }

    }
}
