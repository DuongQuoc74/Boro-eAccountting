using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class NhomKhachHang : FullAuditedEntity<int?>
    {
        public string? NhomKhachHangUd { get; set; }
        public string? NhomKhachHangNm { get; set; }
        public string? NhomKhachHangNm2 { get; set; }
        public int? KieuPhanNhom { get; set; }
    }
}
