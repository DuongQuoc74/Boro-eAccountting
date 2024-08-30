using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class KhachHang : FullAuditedEntity<int?>
    {
        public int? NhomKhachHang1 { set; get; }
        public int? NhomKhachHang2 { set; get; }
        public int? NhomKhachHang3 { set; get; }
        public string? KhachHangUd { set; get; }
        public string? KhachHangNm { set; get; }
        public string? KhachHangNm2 { set; get; }
        public int? Loai { set; get; }
        public int? ChiNhanhId { set; get; }
        public string? DiaChi { set; get; }
        public string? DoiTac { set; get; }
        public string? MaSoThue { set; get; }
        public int? TkNgamDinh { set; get; }
        public int? TkKho { set; get; }
        public int? TkChietKhau { set; get; }
        public int? HanTtNgamDinh { set; get; }
        public bool? IsConGiaoDich { set; get; }
        public decimal? Sodu { set; get; }
        public string? DienThoai { set; get; }
        public string? Fax { set; get; }
        public string? Email { set; get; }
        public string? TkNganHang { set; get; }
        public string? TenNganHang { set; get; }
        public string? TinhThanh { set; get; }
        public string? GhiChu { set; get; }
        public string? MaTd1 { set; get; }
        public DateTime? NgayTd1 { set; get; }
        public decimal? SoLuongTd1 { set; get; }
        public string? GhiChuTd1 { set; get; }
        public string? MaTd2 { set; get; }
        public DateTime? NgayTd2 { set; get; }
        public decimal? SoLuongTd2 { set; get; }
        public string? GhiChuTd2 { set; get; }
        public string? MaTd3 { set; get; }
        public DateTime? NgayTd3 { set; get; }
        public decimal? SoLuongTd3 { set; get; }
        public string? GhiChuTd3 { set; get; }
        public string? DiaDiemGiao { set; get; }
        public List<HoaDonGtgt>? HoaDonGTGTGTs { get; set; }
    }
}
