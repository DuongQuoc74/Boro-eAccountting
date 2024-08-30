using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class DmTruongTuDo : FullAuditedEntity<int?>
    {
        public string? DmTruongTuDoUd { get; set; } 
        public string? DmTruongTuDoNm { get; set; } 
        public string? DmTruongTuDoNm2 { get; set; } 
        public int? LoaiTruongTuDo { get; set; } 
    }
}
