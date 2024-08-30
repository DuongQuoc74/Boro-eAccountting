using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuNhapCT : FullAuditedEntity<int>
    {
        public int? PhieuNhapId { set; get; }
        public PhieuNhap? PhieuNhap { get; set; }
        public int? VatTuId { set; get; }
        public int? KhoId { set; get; }
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
        public int? GhiNoTK { set; get; }
        public bool? IsXuatTraLai { set; get; }
        public int? PhieuXuatChiTietId { set; get; }
        public int? MaPhiId { set; get; }
        public int? VuViecId { set; get; }
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
        public int? DieuChinhThueTNDNId { set; get; }
        public string? ConnectAEVatTu { set; get; }
    }
}
