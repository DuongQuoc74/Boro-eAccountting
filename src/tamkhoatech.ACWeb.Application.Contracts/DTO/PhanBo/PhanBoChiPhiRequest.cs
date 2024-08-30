using System;
using System.Collections.Generic;
using System.Text;
using tamkhoatech.ACWeb.Common;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhanBoChiPhiRequest
    {
        public int? PhieuNhapId { set; get; }
        public int? VatTuId { set; get; }
        public string? VatTuUd { set; get; }
        public string? VatTuNm { set; get; }
        public string? DonViTinh { set; get; }
        public int? KhoId { set; get; }
        public decimal? TienHang { set; get; }
        public decimal? TienHangVND { set; get; }
        public decimal? ChiPhi { set; get; }
        public decimal? ChiPhiVND { set; get; }
        [NullAttribute]
        public int? TkNo { set; get; }
        public string? TkNoUd { set; get; }
        public int? PhieuNhapCtId { set; get; }
        public int? MaPhiId { set; get; }
        public int? VuViecId { set; get; }
        public int? MaTD01 { set; get; }
        public int? MaTD02 { set; get; }
        public int? MaTD03 { set; get; }
        public int? DieuChinhThueTNDNId { set; get; }
        public int? Stt { set; get; }
    }
}
