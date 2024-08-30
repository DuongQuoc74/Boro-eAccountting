using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class FilterRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Id1 { get; set; }
        public string? Value1 { get; set; }
        public int? Id2 { get; set; }
        public string? Value2 { get; set; }
        public int? Id3 { get; set; }
        public string? Value3 { get; set; }
    }
}
