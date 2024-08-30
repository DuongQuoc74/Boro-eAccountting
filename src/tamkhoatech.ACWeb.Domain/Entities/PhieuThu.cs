using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuThu : FullAuditedEntity<int?>
    {
        public string? LoaiPhieu { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? GiaoDichId { get; set; }
        public int? KhachHangId { get; set; }
        public string? NguoiNop { get; set; }
        public int? GhiNoTkId { get; set; }
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoPhieu { get; set; }
        public string? QuyenSoId { get; set; }
        public string? ChungTu { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsTaoTuDong { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuXuatId { get; set; }
        public string? PhieuXuatUd { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? DienGiai { get; set; }
        public List<PhieuThuCT>? PhieuThuCTs { get; set; }
        public List<SoCai>? SoCais { get; set; }
    }
}
