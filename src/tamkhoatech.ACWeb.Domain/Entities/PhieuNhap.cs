using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuNhap : FullAuditedEntity<int?>
    {
        public string? LoaiPhieu { set; get; }
        public int? ChiNhanhId { set; get; }
        public int? KhachHangId { set; get; }
        public string? NguoiGiaoHang { set; get; }
        public string? DienGiai { set; get; }
        public int? GhiCoTk { set; get; }
        public string? Sopn { set; get; }
        public string? QuyenSo { set; get; }
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayLap { set; get; }
        public int? NgoaiTeId { set; get; }
        public decimal? TiGia { set; get; }
        public bool? IsNhapGiaTb { set; get; }
        public int? PhieuNhapMId { set; get; }
        public DateTime? NgayLapM { set; get; }
        public string? SoHd { set; get; }
        public string? SoSeri { set; get; }
        public DateTime? NgayHd { set; get; }
        public int? BoPhanId { set; get; }
        public string? GhiChu { set; get; }
        public string? NhomHang { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? TienVon { set; get; }
        public decimal? TienVonVND { set; get; }
        public decimal? TienHang { set; get; }
        public decimal? TienHangVND { set; get; }
        public decimal? ChiPhi { set; get; }
        public decimal? ChiPhiVND { set; get; }
        public decimal? TongTienHangCp { set; get; }
        public decimal? TongTienHangCpVND { set; get; }
        public decimal? TienChietKhau { set; get; }
        public decimal? TienChietKhauVND { set; get; }
        public decimal? GiamGia1 { set; get; }
        public decimal? GiamGia1VND { set; get; }
        public decimal? GiamGia2 { set; get; }
        public decimal? GiamGia2VND { set; get; }
        public decimal? ThueVat { set; get; }
        public decimal? ThueVatVND { set; get; }
        public decimal? ThueNk { set; get; }
        public decimal? ThueNkVND { set; get; }
        public decimal? TongTien { set; get; }
        public decimal? TongTienVND { set; get; }
        public int? ThueSuatId { set; get; }
        public decimal? ThueSuat { set; get; }
        public decimal? ChietKhau { set; get; }
        public bool? IsChiPhiTinhThue { set; get; }
        public int? HoaDonGTGT { set; get; }
        public int? TkThueNk { set; get; }
        public int? TkThueVat { set; get; }
        public int? TkThueVatDu { set; get; }
        public int? TkGiamGia1 { set; get; }
        public int? TkGiamGia2 { set; get; }
        public int? HanTT { set; get; }
        public bool? IsSuaTtThue { set; get; }
        public bool? IsSuaTienThue { set; get; }
        public bool? IsSuaTkThue { set; get; }
        public decimal? TienHd { set; get; }
        public decimal? TienHdVND { set; get; }
        public decimal? TienPhaiTt { set; get; }
        public decimal? TienPhaiTtVND { set; get; }
        public decimal? ConPhaiTt { set; get; }
        public decimal? ConPhaiTtVND { set; get; }
        public decimal? TienTt { set; get; }
        public decimal? TienTtVND { set; get; }
        public bool? IsTatToan { set; get; }
        public bool? IsChon { set; get; }
        public bool? IsSuaHD { set; get; }
        public int? MauHDId { set; get; }
        public string? MauHDUd { set; get; }
        public string? KyHieuMauHD { set; get; }
        public bool? IsSuaTien { set; get; }
        public string? DiaChi { set; get; }
        public string? MaSoThue { set; get; }
        public int? MauBC { set; get; }
        public int? LoaiThueId { set; get; }
        public bool? IsPostSC { set; get; }
        public string? ChungTuChiPhi { set; get; }
        public decimal? ChietKhauVND { set; get; }
        public int? PhuongPhapChietKhau { set; get; }
        public string? ConnectAE { set; get; }
        public decimal? ChietKhauDaBan { set; get; }
        public decimal? ChietKhauDaBanVND { set; get; }
        public decimal? ChietKhauDungDePhanBo { set; get; }
        public decimal? ChietKhauDungDePhanBoVND { set; get; }
        public int? TkChietKhau { set; get; }
        public bool? IsTaoTuDongToanBoDienGiai { set; get; }
        public List<PhieuNhapCT>? PhieuNhapCTs { get; set; }
        public List<PhanBoChietKhauThuongMai>? PhanBoChietKhauThuongMais { get; set; }
        public List<PhanBoChiPhi>? PhanBoChiPhis { get; set; }
        public List<SoCai>? SoCais { get; set; }
        public List<HoaDonGtgt>? HoaDonGtgts { get; set; }
        public List<PhanBoThueNk>? PhanBoThueNks { get; set; }
        public List<HoaDonMuaHang>? HoaDonMuaHangs { get; set; }
    }
}
