using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy
{
    public class DauKyRequest
    {
        [Required]
        public int? ChiNhanhId { get; set; }
        public string? ChiNhanhNm { get; set; }
        public int? TaiKhoanId { get; set; }
        public string? TaiKhoanNm { get; set; }
        public DateTime Ngay { get; set; }
    }
}
