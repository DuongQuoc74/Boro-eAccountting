using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuXuatKhoCt : FullAuditedEntity<int>
    {
      public int? PhieuXuatKhoId {set; get;}
      public PhieuXuatKho? PhieuXuatKho {set; get;}
      public int? VatTuId {set; get;}
      public int? KhoId {set; get;}
      public DateTime? NgayLo {set; get;}
      public string? SoLo {set; get;}
      public decimal? SoLuong {set; get;}
      public decimal? TonKho {set; get;}
      public decimal? Gia {set; get;}
      public decimal? GiaVND {set; get;}
      public decimal? Tien {set; get;}
      public decimal? TienVND {set; get;}
      public int? GhiCoTk {set; get;}
      public int? GhiNoTk {set; get;}
      public int? MaPhiId {set; get;}
      public int? VuViecId {set; get;}
      public int? BoPhanHTId {set; get;}
      public int? VatTuId1 {set; get;}
      public int? MaTD01 {set; get;}
      public DateTime? NgayTD01 {set; get;}
      public int? SoLuongTD01 {set; get;}
      public string? GhiChuTD01 {set; get;}
      public int? MaTD02 {set; get;}
      public DateTime? NgayTD02 {set; get;}
      public string? SoLuongTD02 {set; get;}
      public string? GhiChuTD02 {set; get;}
      public int? MaTD03 {set; get;}
      public DateTime? NgayTD03 {set; get;}
      public decimal? SoLuongTD03 {set; get;}
      public string? GhiChuTD03 {set; get;}
      public int? DieuChinhThueTNDNId {set; get;}
      public int? DmTapHopChiPhiId {set; get;}
      public int? CongTrinhId {set; get;}
        public List<TheKho>? TheKhos {set; get;}
    }
}
