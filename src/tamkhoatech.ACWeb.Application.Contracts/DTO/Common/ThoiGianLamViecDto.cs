using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class ThoiGianLamViecDto
    {
        [Required]
        public DateTime? TuNgay { get; set; }
        [Required]
        public DateTime? DenNgay { get; set; }
    }
}
