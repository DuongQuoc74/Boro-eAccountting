using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class ManHinhNhapCt : FullAuditedEntity<int>
    {
      public int? ManHinhNhapId {set;get;}
      public ManHinhNhap? ManHinhNhap {set;get;}
      public string? ColumnUd {set;get;}
      public string? ColumnCaption {set;get;}
      public string? ColumnCaption2 {set;get;}
      public int? ColumnOrder {set;get;}
      public int? ColumnWidth {set;get;}
      public bool? IsUse {set;get;}
    }
}
