using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class NavigationNodeDto : EntityDto<int?>
    {
        public string LText { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public int NodeLevel { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public string HelpUrl { get; set; }
    }
}
