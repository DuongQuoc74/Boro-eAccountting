using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class DuDauKyCongNo : FullAuditedEntity<int?>
    {
        public DateTime? Ngay {set; get;}
        public int? ChiNhanhId {set; get;}
        public int? TaiKhoanId {set; get;}
        public int? KhachHangId {set; get;}
        public int? VuViecId {set; get;}
        public int? MaPhiId {set; get;}
        public decimal? DuNo {set; get;}
        public decimal? DuNoVND {set; get;}
        public decimal? DuCo {set; get;}
        public decimal? DuCoVND {set; get;}

    }
}
