using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class TyGiaNgoaiTeDto : EntityDto<int>
    {
        public int NgoaiTeId { get; set; }
        public DateTime Ngay { get; set; }
        public decimal TyGia { get; set; }
    }
}
