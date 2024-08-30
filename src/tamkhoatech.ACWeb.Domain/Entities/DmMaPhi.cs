using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class DmMaPhi : FullAuditedEntity<int?>
    {
        public string? DmMaPhiUd { get; set; }
        public string? DmMaPhiNm { get; set; }
        public string? DmMaPhiNm2 { get; set; }
    }
}
