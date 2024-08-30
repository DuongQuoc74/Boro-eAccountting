using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class TaiKhoanDto : EntityDto<int?>
    {
        public string? TaiKhoanUd { get; set; }
        public string? TaiKhoanNm { get; set; }
        public string? TaiKhoanNm1 { get; set; }
        public string? TaiKhoanNm2 { get; set; }
        public string? TaiKhoanNm3 { get; set; }
    }
}
