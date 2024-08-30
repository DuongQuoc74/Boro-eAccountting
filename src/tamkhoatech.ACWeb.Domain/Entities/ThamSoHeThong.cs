using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class ThamSoHeThong : FullAuditedEntity<int>
    {
        public string? ThamSoHeThongUd { set; get; }
        public string? DienGiai { set; get; }
        public string? GiaTri { set; get; }
        public DateTime? GiaTriDate { set; get; }
        public string? Kieu { set; get; }
        public string? NhomThamSo { set; get; }
        public int? ThuTu { set; get; }
        public bool? IsHidden { set; get; }
    }
}
