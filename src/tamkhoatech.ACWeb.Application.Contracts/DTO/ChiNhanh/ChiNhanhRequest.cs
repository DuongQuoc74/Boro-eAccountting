using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class ChiNhanhRequest
    {
        [Required]
        public string? ChiNhanhUd { get; set; }
        [Required]
        public string? ChiNhanhNm { get; set; }
        public string? ChiNhanhNm2 { get; set; }
    }
}
