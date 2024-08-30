using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class NhomVatTuDto : EntityDto<int?>
    {
        public string? NhomVatTuUd { get; set; }
        public string? NhomVatTuNm { get; set; }
        public string? NhomVatTuNm2 { get; set; }
        public int? KieuPhanNhom { get; set; }
    }
}
