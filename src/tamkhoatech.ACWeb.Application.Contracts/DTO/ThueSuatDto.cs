using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ThueSuatDto : EntityDto<int>
    {
        public string? ThueSuatUd { set; get; }
        public string? ThueSuatNm { set; get; }
        public string? ThueSuatNm2 { set; get; }
        public decimal? GiaTri { set; get; }
        public int? TkCo { set; get; }
        public string? TkCoUd { set; get; }
        public int? TkNo { set; get; }
        public string? TkNoUd { set; get; }
    }
}
