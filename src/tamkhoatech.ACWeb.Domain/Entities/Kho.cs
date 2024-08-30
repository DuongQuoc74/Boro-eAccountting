using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class Kho : FullAuditedEntity<int?>
    {
        public string? KhoUd { get; set; }
        public string? KhoNm { get; set; }
        public string? KhoNm2 { get; set; }
        public int? ChiNhanhId { set; get; }
    }
}
