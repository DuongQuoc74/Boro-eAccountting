using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{   
    public class DmMaPhiDto : EntityDto<int?>
    {
        public string? DmMaPhiUd { get; set; }
        public string? DmMaPhiNm { get; set; }
        public string? DmMaPhiNm2 { get; set; }
    }
}
