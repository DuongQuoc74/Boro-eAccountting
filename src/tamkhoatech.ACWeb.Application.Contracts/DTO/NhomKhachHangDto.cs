using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class NhomKhachHangDto : EntityDto<int?>
    {
        public string? NhomKhachHangUd { get; set; }
        public string? NhomKhachHangNm { get; set; }
        public string? NhomKhachHangNm2 { get; set; }
        public int? KieuPhanNhom { get; set; }
    }
}
