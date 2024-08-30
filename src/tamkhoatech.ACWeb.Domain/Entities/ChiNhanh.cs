using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class ChiNhanh : FullAuditedEntity<int?>
    {
        public string? ChiNhanhUd { get; set; }
        public string? ChiNhanhNm { get; set; }
        public string? ChiNhanhNm2 { get; set; }
    }
}
