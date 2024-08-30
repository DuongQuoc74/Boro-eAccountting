using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.Dto
{
    public class GiaTriTonKhoDto
    {
        public int? VatTuId { set; get; }
        public int? KhoId { set; get; }
        public List<GiaTri> GiaTris { set; get; } = new List<GiaTri>();
        public TonKho TonKho { set; get; } = new TonKho();
    }
    public class GiaTri
    {
        public int? Stt { set; get; }
        public DateTime? NgayCt { set; get; }
        public string? SoCt { set; get; }
        public decimal? SoLuong { set; get; }
        public decimal? GiaVND { set; get; }
        public decimal? TienVND { set; get; }
    }
    public class TonKho
    {
        public decimal? Ton { set; get; }
        public decimal? DaPhat { set; get; }
    }
}
