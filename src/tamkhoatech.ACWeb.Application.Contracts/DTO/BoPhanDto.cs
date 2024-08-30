using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class BoPhanDto : EntityDto<int>
    {
        public string? BoPhanUd { set; get; }
        public string? BoPhanNm { set; get; }
        public string? BoPhanNm2 { set; get; }
    }
}
