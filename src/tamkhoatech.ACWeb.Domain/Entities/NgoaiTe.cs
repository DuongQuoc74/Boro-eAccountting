using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class NgoaiTe : FullAuditedEntity<int?>
    {
        public string? NgoaiTeUd { get; set; }
        public string? NgoaiTeNm { get; set; }
        public string? NgoaiTeNm2 { get; set; }
        public string? Comma { get; set; }
        public string? DvtienLe { get; set; }
        public string? Dvtien { get; set; }
        public string? Chan { get; set; }
        public string? Comma2 { get; set; }
        public string? DvtienLe2 { get; set; }
        public string? Dvtien2 { get; set; }
        public string? Chan2 { get; set; }
        public decimal? So { get; set; }
        public string? ChuAnh { get; set; }
        public string? ChuViet { get; set; }
        public int? DocSoLe { get; set; }
        public List<TyGiaNgoaiTe>? TyGiaNgoaiTes { get; set; }
    }
}
