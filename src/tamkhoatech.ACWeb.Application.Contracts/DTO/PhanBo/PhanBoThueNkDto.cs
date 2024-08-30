using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhanBoThueNkDto : EntityDto<int>
    {
        public int? PhieuNhapId { set; get; }
        public int? VatTuId { set; get; }
        public string? VatTuUd { set; get; }
        public string? VatTuNm { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? Gia { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? Tien { set; get; }
        public decimal? TienVND { set; get; }
        public decimal? ThueNk { set; get; }
        public decimal? ThueNkVND { set; get; }
        public int? TkNo { set; get; }
        public string? TkNoUd { set; get; }
        public int? MaPhiId { set; get; }
        public int? VuViecId { set; get; }
        public int? MaTD01 { set; get; }
        public int? MaTD02 { set; get; }
        public int? MaTD03 { set; get; }
        public int? Stt { set; get; }
    }
}
