using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class KhoRequest
    {
        [Required]
        public string? KhoUd { set; get; }
        [Required]
        public string? KhoNm { set; get; }
        public string? KhoNm2 { set; get; }
        [Required]
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhUd { set; get; }
        public string? ChiNhanhNm { set; get; }
    }
}
