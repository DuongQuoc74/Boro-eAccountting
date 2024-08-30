using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class DuDauKyTk : FullAuditedEntity<int?>
    {
        public int? ChiNhanhId { set; get; }
        public DateTime? Ngay { set; get; }
        public int? TaiKhoanId { set; get; }
        public decimal? DuNoDauKy { set; get; }
        public decimal? DuNoDauKyVND { set; get; }
        public decimal? DuCoDauKy { set; get; }
        public decimal? DuCoDauKyVND { set; get; }
        public decimal? DuNoDauNam { set; get; }
        public decimal? DuNoDauNamVND { set; get; }
        public decimal? DuCoDauNam { set; get; }
        public decimal? DuCoDauNamVND { set; get; }
    }
}
