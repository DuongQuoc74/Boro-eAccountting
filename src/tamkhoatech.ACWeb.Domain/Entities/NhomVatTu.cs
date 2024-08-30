using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class NhomVatTu : FullAuditedEntity<int?>
    {
        public string? NhomVatTuUd { get; set; }
        public string? NhomVatTuNm { get; set; }
        public string? NhomVatTuNm2 { get; set; }
        public int? KieuPhanNhom { get; set; }
    }
}
