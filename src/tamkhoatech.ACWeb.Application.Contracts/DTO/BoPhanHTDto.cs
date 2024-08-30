using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class BoPhanHTDto : EntityDto<int?>
    {
        public string? BoPhanHtUd { get; set; }
        public string? BoPhanHtNm { get; set; }
        public string? BoPhanHtNm2 { get; set; }
    }
}
