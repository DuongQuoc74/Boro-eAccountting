using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ManHinhNhapCtDto : EntityDto<int>
    {
        public int? ManHinhNhapId { set; get; }
        public string? ColumnUd { set; get; }
        public string? ColumnCaption { set; get; }
        public string? ColumnCaption2 { set; get; }
        public int? ColumnOrder { set; get; }
        public int? ColumnWidth { set; get; }
        public bool? IsUse { set; get; }
    }
}
