using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto 
{
    public class MaGiaoDichDto : EntityDto<int?>
    {
        public string? MaGiaoDichUd { get; set; }
        public string? MaGiaoDichNm { get; set; }
        public string? MaGiaoDichNm2 { get; set; }
        public int? ManHinhNhapId { get; set; }
        public int? TkNo { get; set; }
        public int? TkCo { get; set; }
        public string? DienGiai { get; set; }
    }
}
