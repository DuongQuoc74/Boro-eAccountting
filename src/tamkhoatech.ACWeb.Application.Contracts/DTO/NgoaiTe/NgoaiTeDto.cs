using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class NgoaiTeDto : EntityDto<int?>
    {
        public string? NgoaiTeUd { get; set; }
        public string? NgoaiTeNm { get; set; }
        public string? NgoaiTeNm2 { get; set; }
        public List<TyGiaNgoaiTeDto>? TyGiaNgoaiTeDtos { set; get; }
    }
}
