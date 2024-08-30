using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
   public class DmTruongTuDoDto : EntityDto<int?>
   {
        public string? DmTruongTuDoUd { get; set; }
        public string? DmTruongTuDoNm { get; set; }
        public string? DmTruongTuDoNm2 { get; set; }
        public int? LoaiTruongTuDo { get; set; }
   }
}
