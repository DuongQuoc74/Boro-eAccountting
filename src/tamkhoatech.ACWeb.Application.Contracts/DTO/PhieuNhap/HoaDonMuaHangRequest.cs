using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class HoaDonMuaHangRequest
    {
        public int? Stt { set; get; }
        public int? PhieuNhapId { set; get; }
        public int? KhachHangId { set; get; }
        [NullAttribute]
        public int? GhiNoTK { set; get; }
        public string? GhiNoTKUd { set; get; }
        public string? GhiNoTKNm { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public string? NhomDk { set; get; }
        public string? DienGiai { set; get; }
        public int? VuViecId { set; get; }
        public string? VuViecUd { set; get; }
        public int? MaPhiId { set; get; }
        public string? MaPhiUd { set; get; }
        public int? BoPhanHTId { set; get; }
        public string? BoPhanHTUd { set; get; }
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
        public string? ConnectAEDichVu { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public string? DmTapHopChiPhiUd { set; get; }
        public int? CongTrinhId { set; get; }
        public string? CongTrinhUd { set; get; }
    }
}
