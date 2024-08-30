using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuKeToanCtRequest
    {
        public int? Id { get; set; }
        public int? PhieuKeToanId { set; get; }
        [NullAttribute]
        public int? TaiKhoanId { set; get; }
        public string? TaiKhoanUd { set; get; }
        public string? TaiKhoanNm { set; get; }
        [NullAttribute]
        public int? KhachHangId { set; get; }
        public string? KhachHangUd { set; get; }
        public string? KhachHangNm { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public string? DienGiai { set; get; }
        public string? NhomDk { set; get; }
        public int? VuViecId { set; get; }
        public int? MaPhiId { set; get; }
        public int? BoPhanHTId { set; get; }
        public string? BoPhanHTUd { set; get; }
        public int? VatTuId1 { set; get; }
        public string? VatTuUd { set; get; }
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
        public int? DieuChinhThueTNDNId { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
        public string? CongTrinhUd { set; get; }
    }
}
