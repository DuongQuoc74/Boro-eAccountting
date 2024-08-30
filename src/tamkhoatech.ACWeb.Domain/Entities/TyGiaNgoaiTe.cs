using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class TyGiaNgoaiTe : FullAuditedEntity<int?>
    {
        public int? NgoaiTeId { get; set; }
        public NgoaiTe? NgoaiTe { get; set; }
        public DateTime? Ngay { get; set; }
        public decimal? TyGia { get; set; }
    }
}
