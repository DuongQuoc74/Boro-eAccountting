using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyCongNo
{
    public class DuDauKyCongNoRequest
    {
        public int? Id { set; get; }
        public DateTime? Ngay { set; get; }
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhUd { set; get; }
        public string? ChiNhanhNm { set; get; }
        [Required]
        public int? TaiKhoanId { set; get; }
        public string? TaiKhoanUd { set; get; }
        public string? TaiKhoanNm { set; get; }
        [Required]
        public int? KhachHangId { set; get; }
        public string? KhachHangUd { set; get; }
        public string? KhachHangNm { set; get; }
        public int? VuViecId { set; get; }
        public string? VuViecNm { set; get; }
        public string? VuViecUd { set; get; }
        public int? MaPhiId { set; get; }
        public string? MaPhiUd { set; get; }
        public string? MaPhiNm { set; get; }
        public decimal? DuNo { set; get; }
        public decimal? DuNoVND { set; get; }
        public decimal? DuCo { set; get; }
        public decimal? DuCoVND { set; get; }
    }
}
