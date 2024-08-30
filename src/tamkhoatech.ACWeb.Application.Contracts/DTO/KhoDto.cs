using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class KhoDto : EntityDto<int?>
    {
        public string? KhoUd { get; set; }
        public string? KhoNm { get; set; }
        public string? KhoNm2 { get; set; }
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhUd { set; get; }
        public string? ChiNhanhNm { set; get; }
    }
}
