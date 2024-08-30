using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class DmChungDto : EntityDto<int?>
    {
        public string? DMChungUd { get; set; }
        public string? DMChungNm { get; set; }
        public string? LoaiDM { get; set; }
    }
}
