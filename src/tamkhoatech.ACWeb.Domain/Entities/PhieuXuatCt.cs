using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuXuatCt : FullAuditedEntity<int>
    {
        public int? PhieuXuatId { set; get; }
        public PhieuXuat? PhieuXuat { set; get; }
        public int? VatTuId { set; get; }
        public int? KhoId { set; get; }
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
        public int? TkKho { set; get; }
        public int? TkGiaVon { set; get; }
        public decimal? TyLeCk { set; get; }
        public decimal? TienCk { set; get; }
        public decimal? TienCkVND { set; get; }
        public int? TkChietKhau { set; get; }
        public int? GhiCoTk { set; get; }
        public bool? IsNhapTraLai { set; get; }
        public int? PhieuNhapChiTietId { set; get; }
        public int? PhieuChonCtId { set; get; }
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
        public string? VatTuNm3 { set; get; }
        public int? DieuChinhThueTNDNId { set; get; }
        public string? ConnectAEVatTu { set; get; }
        public int? ThueSuatId { set; get; }
        public decimal? ThueSuat { set; get; }
        public decimal? Thue { set; get; }
        public decimal? ThueVND { set; get; }
        public int? TkThue { set; get; }
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
        public TheKho? TheKho { get; set; }
    }
}
