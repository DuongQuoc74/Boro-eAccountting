using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuKeToanCt : FullAuditedEntity<int>
    {
        public int? PhieuKeToanId { set; get; }
        public PhieuKeToan? PhieuKeToan { set; get; }
        public int? TaiKhoanId { set; get; }
        public int? KhachHangId { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public string? DienGiai { set; get; }
        public string? NhomDk { set; get; }
        public int? VuViecId { set; get; }
        public int? MaPhiId { set; get; }
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
        public int? DmTapHopChiPhiId { set; get; }
        public int? CongTrinhId { set; get; }
    }
}
