using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class SoCai : FullAuditedEntity<int?>
    {
        public int? PhieuNhapId { get; set; }
        public PhieuNhap? PhieuNhap { get; set; }
        public int? PhieuXuatId { get; set; }
        public PhieuXuat? PhieuXuat { get; set; }
        public int? PhieuThuId { get; set; }
        public PhieuThu? PhieuThu { get; set; }
        public int? PhieuChiId { get; set; }
        public PhieuChi? PhieuChi { get; set; }
        public int? PhieuNhapKhoId { get; set; }
        public int? PhieuXuatKhoId { get; set; }
        public PhieuXuatKho? PhieuXuatKho { get; set; }
        public int? PhieuXuatDcKhoId { get; set; }
        public PhieuXuatDcKho? PhieuXuatDcKho { get; set; }
        public int? PhieuKeToanId { get; set; }
        public PhieuKeToan? PhieuKeToan { get; set; }
        public string? KHTSCDId { get; set; }
        public int? DuDauKyTkId { get; set; }
        public int? ButToanKcId { get; set; }
        public int? ButToanPbId { get; set; }
        public int? ButToanCLTGId { get; set; }
        public string? MaNk { get; set; }
        public int? MaGd { get; set; }
        public DateTime? NgayHt { get; set; }
        public DateTime? NgayLap { get; set; }
        public string? SoCt { get; set; }
        public string? SoDh { get; set; }
        public string? SoLo { get; set; }
        public string? PhieuUd { get; set; }
        public DateTime? NgayLo { get; set; }
        public int? KhachHangId { get; set; }
        public string? DienGiai { get; set; }
        public string? NhomDinhKhoan { get; set; }
        public int? Tk { get; set; }
        public int? TkDoiUng { get; set; }
        public decimal? PhatSinhNo { get; set; }
        public decimal? PhatSinhCo { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public decimal? TyGiaHt { get; set; }
        public decimal? TyGiaHt2 { get; set; }
        public decimal? PhatSinhNoVND { get; set; }
        public decimal? PhatSinhCoVND { get; set; }
        public int? Nxt { get; set; }
        public int? VuViecId { get; set; }
        public int? MaPhiId { get; set; }
        public int? MaTD01 { get; set; }
        public int? MaTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public int? ChiNhanhId { get; set; }
        public int? MaTd { get; set; }
        public int? MaKu { get; set; }
        public string? SoHd { get; set; }
        public string? SoSeri { get; set; }
        public DateTime? NgayHd { get; set; }
        public string? SoCTGS { get; set; }
        public DateTime? NgayCTGS { get; set; }
        public string? SoQuyen { get; set; }
        public string? Phieu_ud { get; set; }
        public int? BoPhanHTId { get; set; }
        public int? VatTuId { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }
    }
}
