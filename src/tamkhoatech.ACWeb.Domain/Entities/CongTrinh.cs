using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class CongTrinh : FullAuditedEntity<int?>
    {
        public string? CongTrinhUd { set; get; }
        public string? CongTrinhNm { set; get; }
        public string? CongTrinhNm2 { set; get; }
        public DateTime? NgayBatDau { set; get; }
        public DateTime? NgayKetThuc { set; get; }
        public decimal? DuToan { set; get; }
        public string? ChuDauTu { set; get; }
        public string? DienGiai { set; get; }
        public int? CongTrinhId1 { set; get; }
        public bool? IsNghiemThu { set; get; }
        public string? DisplayUd { set; get; }
        public int? IsCongTrinh { set; get; }
    }
}
