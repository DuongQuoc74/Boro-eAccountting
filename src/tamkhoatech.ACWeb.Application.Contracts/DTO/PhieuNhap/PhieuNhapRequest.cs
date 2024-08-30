using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuNhapRequest
    {
        public string? LoaiPhieu { set; get; }
        [Required]
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhNm { set; get; }
        [Required]
        public int? KhachHangId { set; get; }
        public string? KhachHangUd { set; get; }
        public string? KhachHangNm { set; get; }
        public decimal? SoDu { set; get; }
        public string? DiaChi { set; get; }
        public string? MaSoThue { set; get; }
        public string? NguoiGiaoHang { set; get; }
        public string? DienGiai { set; get; }
        [Required]
        public int? GhiCoTk { set; get; }
        public string? GhiCoTkUd { set; get; }
        public string? GhiCoTkNm { set; get; }
        public string? Sopn { set; get; }
        public string? QuyenSo { set; get; }
        [Required]
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayLap { set; get; }
        public int? NgoaiTeId { set; get; }
        public string? NgoaiTeUd { set; get; }
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
        [Required]
        public int? TkThueNk { set; get; }
        public int? TkThueVat { set; get; }
        public string? TkThueVatUd { set; get; }
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
        [Required]
        public int? TkChietKhau { set; get; }
        public bool? IsTaoTuDongToanBoDienGiai { set; get; }
        public List<PhieuNhapCtRequest>? PhieuNhapCtRequests { set; get; }
        public List<HoaDonRequest>? HoaDonRequests { set; get; }
        public List<PhanBoChietKhauThuongMaiRequest>? PhanBoChietKhauThuongMaiRequests { set; get; }
        public List<PhanBoChiPhiRequest>? PhanBoChiPhiRequests { set; get; }
        public List<PhanBoThueNkRequest>? PhanBoThueNkRequests { set; get; }
        public List<SoCaiRequest>? SoCaiRequests { set; get; }
        public List<HoaDonMuaHangRequest>? HoaDonMuaHangRequests { set; get; }
    }
}
