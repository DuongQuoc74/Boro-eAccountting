using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhanBoThueNk : FullAuditedEntity<int>
    {
        public int? PhieuNhapId { set; get; }
        public PhieuNhap? PhieuNhap { set; get; }
        public int? VatTuId { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? ThueNk { set; get; }
        public decimal? ThueNkVND { set; get; }
        public int? TkNo { set; get; }
        public int? MaPhiId { set; get; }
        public int? VuViecId { set; get; }
        public int? MaTD01 { set; get; }
        public int? MaTD02 { set; get; }
        public int? MaTD03 { set; get; }
    }
}
