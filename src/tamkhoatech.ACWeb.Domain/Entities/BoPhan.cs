using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class BoPhan : FullAuditedEntity<int>
    {
        public string? BoPhanUd { set; get; }
        public string? BoPhanNm { set; get; }
        public string? BoPhanNm2 { set; get; }
    }
}
