using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class MaGiaoDich : FullAuditedEntity<int?>
    {
        public string? MaGiaoDichUd { get; set; }
        public string? MaGiaoDichNm { get; set; }
        public string? MaGiaoDichNm2 { get; set; }
        public int? ManHinhNhapId { get; set; }
        public int? TkNo { get; set; }
        public int? TkCo { get; set; }
        public string? DienGiai { get; set; }
    }
}
