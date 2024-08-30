using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class QuyenSo : FullAuditedEntity<int?>
    {
        public string? MaCt { get; set; }
        public string? SoQuyen { get; set; }
        public int? SoCtHienTai { get; set; }
        public int? SoKyTu0 { get; set; }
        public string? SoCtPrefix { get; set; }
        public string? SoCtSuffix { get; set; }
        public bool? IsUser { get; set; }
    }
}
