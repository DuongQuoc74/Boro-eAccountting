using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class QuyenSoDto : EntityDto<int?>
    {
        public string? MaCt { get; set; }
        public string? SoQuyen { get; set; }
        public int? SoCtHienTai { get; set; }
        public int? SoKyTu0 { get; set; }
        public bool? IsUser { get; set; }
    }
}
