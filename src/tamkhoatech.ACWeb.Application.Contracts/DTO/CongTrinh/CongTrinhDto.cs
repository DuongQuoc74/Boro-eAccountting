using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class CongTrinhDto : EntityDto<int?>
    {
        public string? CongTrinhUd { set; get; }
        public string? CongTrinhNm { set; get; }
        public string? CongTrinhNm2 { set; get; }
        public DateTime? NgayBatDau { set; get; }
        public DateTime? NgayKetThuc { set; get; }
        public decimal? DuToan { set; get; }
        public string? ChuDauTu { set; get; }
        public string? DienGiai { set; get; }
        public int? CongTrinhId1 { set; get; }
        public string? CongTrinhUd1 { set; get; }
        public bool? IsNghiemThu { set; get; }
        public string? DisplayUd { set; get; }
        public int? IsCongTrinh { set; get; }
    }
}
