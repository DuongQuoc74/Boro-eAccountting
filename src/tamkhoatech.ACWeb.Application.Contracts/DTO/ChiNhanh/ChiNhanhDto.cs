using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ChiNhanhDto : EntityDto<int?>
    {
        public string? ChiNhanhUd { get; set; }
        public string? ChiNhanhNm { get; set; }
        public string? ChiNhanhNm2 { get; set; }
    }
}
