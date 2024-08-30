using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuKeToan : FullAuditedEntity<int?>
    {
        public string? LoaiPhieu { set; get; }
        public int? ChiNhanhId { set; get; }
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayCt { set; get; }
        public string? SoCt { set; get; }
        public string? QuyenSo { set; get; }
        public int? NgoaiTeId { set; get; }
        public decimal? TyGia { set; get; }
        public decimal? PsNo { set; get; }
        public decimal? PsNoVND { set; get; }
        public decimal? PsCo { set; get; }
        public decimal? PsCoVND { set; get; }
        public int? RefId { get; set; }
        public bool? IsSuaTien { set; get; }
        public bool? IsPostSC { set; get; }
        public bool? IsNghiemThu { set; get; }
        public string? DienGiai { get; set; }
        public List<PhieuKeToanCt>? PhieuKeToanCts { get; set; }
        public List<SoCai>? SoCais { get; set; }
        public List<HoaDonGtgt>? HoaDonGTGTs { get; set; }
    }
}
