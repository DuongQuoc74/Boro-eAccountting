using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class DieuChinhThueTNDN : FullAuditedEntity<int?>
    {
        public string? DieuChinhThueTNDNUd { get; set; }
        public string? DieuChinhThueTNDNNm { get; set; }
        public string? DieuChinhThueTNDNNm2 { get; set; }
    }
}
