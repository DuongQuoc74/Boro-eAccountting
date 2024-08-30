using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class ThueSuat : FullAuditedEntity<int>
    {
        public string? ThueSuatUd { set; get; }
        public string? ThueSuatNm { set; get; }
        public string? ThueSuatNm2 { set; get; }
        public decimal? GiaTri { set; get; }
        public int? TkCo { set; get; }
        public int? TkNo { set; get; }
    }
}
