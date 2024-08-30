using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace tamkhoatech.ACWeb.Entities
{
    public class SYNavigationNode : Entity<int?>
    {
        public string LText { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public int NodeLevel { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public string HelpUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
