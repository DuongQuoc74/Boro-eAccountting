using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class TonKho : FullAuditedEntity<int?>
    {
        public DateTime? NgayCt { set; get; }
        public string? SoCt { set; get; }
        public int? TaiKhoanId { set; get; }
        public int? KhoId { set; get; }
        public int? VatTuId { set; get; }
        public DateTime? NgayLo { set; get; }
        public string? SoLo { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
    }
}
