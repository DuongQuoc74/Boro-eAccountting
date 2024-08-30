using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class BoPhanHT : FullAuditedEntity<int?>
    {
        public string? BoPhanHtUd { get; set; }
        public string? BoPhanHtNm { get; set; }
        public string? BoPhanHtNm2 { get; set; }
    }
}
