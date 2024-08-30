using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class TaiKhoan : FullAuditedEntity<int?>
    {
        public string? TaiKhoanUd { get; set; }
        public string? TaiKhoanNm { get; set; }
        public string? TaiKhoanNm1 { get; set; }
        public string? TaiKhoanNm2 { get; set; }
        public string? TaiKhoanNm3 { get; set; }
        public int? NgoaiTeId { get; set; }
        public int? TaiKhoanParentId { get; set; }
        public bool? IsTKCongNo { get; set; }
        public bool? IsTKSoCai { get; set; }
        public int? BacTK { get; set; }
        public bool? IsBacCuoi { get; set; }
        public int? NhomTieuKhoanId { get; set; }
        public int? NhomTaiKhoanId { get; set; }
        public int? TGGSNo { get; set; }
        public int? TGGSCo { get; set; }
        public bool? IsDk { get; set; }
        public bool? IsVisible { get; set; }
        public int? Loai { get; set; }
        public int? TieuKhoanId { get; set; }
        public bool? IsTKVatTu { get; set; }
    }
}
