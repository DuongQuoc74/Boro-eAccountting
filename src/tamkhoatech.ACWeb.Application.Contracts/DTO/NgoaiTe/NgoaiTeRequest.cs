using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class NgoaiTeRequest
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
        public List<TyGiaNgoaiTeRequest>? TyGiaNgoaiTeCreateRequests { get; set; }
    }
}
