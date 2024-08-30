using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatRequest
    {
        public string? LoaiPhieu { set; get; }
        [Required]
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhNm { set; get; }
        public int? GiaoDichId { set; get; }
        public int? MauHoaDonId { set; get; }
        [Required]
        public int? KhachHangId { set; get; }
        public string? KhachHangUd { set; get; }
        public string? KhachHangNm{ set; get; }
        public string? NguoiMuaHang { set; get; }
        public string? NguoiGiaoHang { set; get; }
        public string? DienGiai { set; get; }
        [Required]
        public int? GhiNoTk { set; get; }
        public string? GhiNoTkNm { set; get; }
        public string? GhiNoTkUd { set; get; }
        public string? GhiChu { set; get; }
        public int? BoPhanId { set; get; }
        public string? BoPhanNm { set; get; }
        public string? HinhThucTt { set; get; }
        public string? SoCt { set; get; }
        public string? QuyenSo { set; get; }
        public string? SoHd { set; get; }
        public string? SoSeri { set; get; }
        public DateTime? NgayHt { set; get; }
        public DateTime? NgayLap { set; get; }
        [Required]
        public int? NgoaiTeId { set; get; }
        public string? NgoaiTeUd { set; get; }
        public decimal? TiGia { set; get; }
        public bool? IsGiaVonDD { set; get; }
        public string? NhomHang { set; get; }
        public int? MauBC { set; get; }
        public int? LoaiThueId { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? TienVon { set; get; }
        public decimal? TienVonVND { set; get; }
        public decimal? TienHang { set; get; }
        public decimal? TienHangVND { set; get; }
        public decimal? TienChietKhau { set; get; }
        public decimal? TienChietKhauVND { set; get; }
        public decimal? TienHangCk { set; get; }
        public decimal? TienHangCkVND { set; get; }
        public decimal? ThueVat { set; get; }
        public decimal? ThueVatVND { set; get; }
        public decimal? TongTien { set; get; }
        public decimal? TongTienVND { set; get; }
        public int? ThueSuatId { set; get; }
        public string? ThueSuatUd { set; get; }
        public decimal? ThueSuat { set; get; }
        public int? TkThueVat { set; get; }
        [Required]
        public int? TkThueVatDu { set; get; }
        [Required]
        public int? TkChietKhau { set; get; }
        public bool? IsSuaTienThue { set; get; }
        public bool? IsSuaTkThue { set; get; }
        public bool? IsSuaTienCk { set; get; }
        public int? HanTt { set; get; }
        public decimal? TienHd { set; get; }
        public decimal? TienHdVND { set; get; }
        public decimal? TienPhaiTt { set; get; }
        public decimal? TienPhaiTtVND { set; get; }
        public decimal? ConPhaiTt { set; get; }
        public decimal? ConPhaiTtVND { set; get; }
        public decimal? TienTt { set; get; }
        public decimal? TienTtVND { set; get; }
        public bool? IsTatToan { set; get; }
        public bool? IsXem { set; get; }
        public bool? IsDaIn { set; get; }
        public string? SoHopDong { set; get; }
        public DateTime? NgayHopDong { set; get; }
        public string? DiaDiemGiao { set; get; }
        public string? DiaDiemNhan { set; get; }
        public string? SoVanDon { set; get; }
        public DateTime? NgayVanDon { set; get; }
        public string? SoContainer { set; get; }
        public string? TenDvvc { set; get; }
        public bool? IsSuaHD { set; get; }
        public int? MauHDId { set; get; }
        public string? MauHDUd { set; get; }
        public string? KyHieuMauHD { set; get; }
        public bool? IsSuaTien { set; get; }
        public string? DiaChi { set; get; }
        public string? MaSoThue { set; get; }
        public decimal? SoDu { set; get; }
        public bool? IsAmThue { set; get; }
        public bool? IsPostSC { set; get; }
        public bool? EInvoice { set; get; }
        public DateTime? ECreatedDate { set; get; }
        public DateTime? EModifiedDate { set; get; }
        public string? ECreatedBy { set; get; }
        public string? TienBangChu { set; get; }
        public DateTime? EResultDate { set; get; }
        public string? EResultBy { set; get; }
        public string? Email { set; get; }
        public string? DienThoai { set; get; }
        public string? TkNganHang { set; get; }
        public string? Fax { set; get; }
        public string? EResult { set; get; }
        public string? SyncError { set; get; }
        public bool? IsBoTrongGia { set; get; }
        public string? mInvoiceInvoiceAuthId { set; get; }
        public string? mInvoiceSovb { set; get; }
        public DateTime? mInvoiceNgayvb { set; get; }
        public string? mInvoiceGhiChu { set; get; }
        public bool? IsHuy { set; get; }
        public string? ViettelInvoicetransactionID { set; get; }
        public string? ViettelInvoicereservationCode { set; get; }
        public string? CA2HoaDonID { set; get; }
        public string? CA2KeyTichHop { set; get; }
        public string? CA2MaTraCuu { set; get; }
        public string? HoaDonVietInvoiceAuthId { set; get; }
        public string? ViettelInvoiceSupplierTaxCode { set; get; }
        public string? ViettelInvoiceTransactionUuid { set; get; }
        public string? ConnectAE { set; get; }
        public bool? IsSuaTienSauThue { set; get; }
        public List<SoCaiRequest>? SoCaiRequests { set; get; }
        public List<HoaDonRequest>? HoaDonRequests { set; get; }
        public List<HoaDonBanHangRequest>? HoaDonBanHangRequests { set; get; }
        public List<PhieuXuatCtRequest>? PhieuXuatCtRequests { set; get; }
    }
}
