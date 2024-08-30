using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class HoaDonGtgt : FullAuditedEntity<int>
    {
        public int? PhieuNhapId { get; set; }
        public PhieuNhap? PhieuNhap { get; set; }
        public int? PhieuXuatId { get; set; }
        public PhieuXuat? PhieuXuat { get; set; }
        public int? PhieuChiId { get; set; }
        public PhieuChi? PhieuChi { get; set; }
        public int? PhieuKeToanId { get; set; }
        public PhieuKeToan? PhieuKeToan { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? MauBC { get; set; }
        public int? LoaiThue { get; set; }
        public string? MaCt { get; set; }
        public DateTime? NgayCt { get; set; }
        public string? SoCt { get; set; }
        public DateTime? NgayCt0 { get; set; }
        public string? SoCt0 { get; set; }
        public string? SoSeri0 { get; set; }
        public int? KhachHangId { get; set; }
        public KhachHang? KhachHang { get; set; }
        public string? KhachHangUd { get; set; }
        public string? KhachHangNm { get; set; }
        public string? DiaChi { get; set; }
        public string? MaSoThue { get; set; }
        public int? KhoId { get; set; }
        public int? VuViecId { get; set; }
        public string? VatTu { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiaVND { get; set; }
        public decimal? Tien { get; set; }
        public decimal? TienVND { get; set; }
        public decimal? Thue { get; set; }
        public decimal? ThueVND { get; set; }
        public int? MaThue { get; set; }
        public decimal? ThueSuat { get; set; }
        public int? TkThue { get; set; }
        public int? TkDu { get; set; }
        public string? CucThue { get; set; }
        public string? GhiChu { get; set; }
        public int? MaTuDo { get; set; }
        public int? MaPhiId { get; set; }
        public int? MaTD01 { get; set; }
        public int? MaTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public bool? IsPhieu { get; set; }
        public int? MauHDId { get; set; }
        public string? MauHDUd { get; set; }
        public string? KyHieuMauHD { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }

    }
}
