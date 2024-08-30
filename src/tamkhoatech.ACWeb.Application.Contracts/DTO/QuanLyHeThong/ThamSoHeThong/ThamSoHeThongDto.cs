using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ThamSoHeThongDto : EntityDto<int>
    {
        public string? ThamSoHeThongUd { set; get; }
        public string? DienGiai { set; get; }
        public string? GiaTri { set; get; }
        public DateTime? GiaTriDate { set; get; }
        public string? Kieu { set; get; }
        public string? NhomThamSo { set; get; }
        public int? ThuTu { set; get; }
        public bool? IsHidden { set; get; }
    }
}
