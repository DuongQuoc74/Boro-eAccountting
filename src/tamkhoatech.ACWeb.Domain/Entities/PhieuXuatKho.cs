using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuXuatKho : FullAuditedEntity<int?>
    {
      public string? LoaiPhieu {set;get;}
      public int? ChiNhanhId {set;get;}
      public int? GiaoDichId {set;get;}
      public int? KhachHangId {set;get;}
      public string? NgNhanHang {set;get;}
      public string? DienGiai {set;get;}
      public string? SoCt {set;get;}
      public string? QuyenSo {set;get;}
      public DateTime? NgayHt {set;get;}
      public DateTime? NgayLap {set;get;}
      public int? NgoaiTeId {set;get;}
      public decimal? TyGia {set;get;}
      public bool? IsXuatGiaDd {set;get;}
      public decimal? SoLuong {set;get;}
      public decimal? TongTien {set;get;}
      public decimal? TongTienVND {set;get;}
      public int? RefId {set;get;}
      public bool? IsSuaTien {set;get;}
      public bool? IsPostSC {set;get;}
      public int? PhieuXuatId {set;get;}
      public int? PhieuNhapKhoId {set;get;}
      public int? PhieuDieuChinhKhoId {set;get;}
      public int? LenhSanXuatId {set;get;}
        public List<PhieuXuatKhoCt>? PhieuXuatKhoCts { get; set; }
        public List<SoCai>? SoCais { get; set; }
    }
}
