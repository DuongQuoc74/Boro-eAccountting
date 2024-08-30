using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuChi : FullAuditedEntity<int?>
    {
        public string? LoaiPhieu { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? GiaoDichId { get; set; }
        public int? KhachHangId { get; set; }
        public string? NguoiNhan { get; set; }
        public int? GhiNoTkId { get; set; }
        public DateTime? NgayHT { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoPhieu { get; set; }
        public string? QuyenSoId { get; set; }
        public string? ChungTu { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TyGiaGS { get; set; }
        public int? HoaDonGTGT { get; set; }
        public int? TkThue { get; set; }
        public decimal? Tien { get; set; }
        public decimal? TienVND { get; set; }
        public decimal? TienThue { get; set; }
        public decimal? TienThueVND { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? TongTienVND { get; set; }
        public int? RefId { get; set; }
        public string? TenNganHang { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? TenTinhThanh { get; set; }
        public string? TenKhachHang { get; set; }
        public string? DiaChi { get; set; }
        public string? SoTaiKhoan2 { get; set; }
        public string? TenNganHang2 { get; set; }
        public string? DiaChi2 { get; set; }
        public string? NoiDung { get; set; }
        public string? CamKet { get; set; }
        public int? MucDich { get; set; }
        public int? HinhThuc { get; set; }
        public int? PhiTrong { get; set; }
        public int? PhiNgoai { get; set; }
        public string? DiaChiKH { get; set; }
        public string? MaSoThue { get; set; }
        public bool? IsSuaTien { get; set; }
        public bool? IsTaoTuDong { get; set; }
        public bool? IsPostSC { get; set; }
        public int? PhieuNhapId { get; set; }
        public string? PhieuNhapUd { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? DienGiai { get; set; }
        public List<PhieuChiCT>? PhieuChiCTs { get; set; }
        public List<HoaDonGtgt>? HoaDonGTGTs { get; set; }
        public List<SoCai>? SoCais { get; set; }
    }
}
