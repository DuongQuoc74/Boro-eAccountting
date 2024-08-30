using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class HoaDonBanHang : FullAuditedEntity<int>
    {
        public int? PhieuXuatId { set; get; }
        public PhieuXuat? PhieuXuat { set; get; }
        public int? KhachHangId { set; get; }
        public int? TkDoanhThu { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public string? NhomDk { set; get; }
        public int? ThueSuatId { set; get; }
        public decimal? ThueSuat { set; get; }
        public decimal? Thue { set; get; }
        public decimal? ThueVND { set; get; }
        public int? TkThue { set; get; }
        public string? DienGiai { set; get; }
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
    }
}
