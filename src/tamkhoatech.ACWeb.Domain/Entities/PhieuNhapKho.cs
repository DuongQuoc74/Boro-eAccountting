using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuNhapKho : FullAuditedEntity<int?>
    {
        public string? LoaiPhieu { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? GiaoDichId { get; set; }
        public int? KhachHangId { get; set; }
        public string? NgGiaoHang { get; set; }
        public string? DienGiai { get; set; }
        public string? SoCt { get; set; }
        public string? QuyenSo { get; set; }
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public bool? IsNhapGiaTb { get; set; }
        public bool? IsNhapThuHoi { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuXuatId { get; set; }
        public bool? IsTaoPhieuXuatKho { get; set; }
        public int? PhieuDieuChinhKhoId { get; set; }
        public int? KhoXuatNVLId { get; set; }
        public int? LenhSanXuatId { get; set; }
        public List<PhieuNhapKhoCt>? PhieuNhapKhoCts { get; set; }
        public List<SoCai>? SoCais { get; set; }
    }
}
