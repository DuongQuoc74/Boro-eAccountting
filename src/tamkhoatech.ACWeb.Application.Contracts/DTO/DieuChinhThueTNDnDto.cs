using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class DieuChinhThueTNDnDto : EntityDto<int?>
    {
        public string? DieuChinhThueTNDNUd { get; set; }
        public string? DieuChinhThueTNDNNm { get; set; }
        public string? DieuChinhThueTNDNNm2 { get; set; }
    }
}
