using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ManHinhNhapDto : EntityDto<int>
    {
        public string? ChungTuUd { set; get; }
        public string? ChungTuNm { set; get; }
        public string? ChungTuNm2 { set; get; }
        public string? ChungTuMUd { set; get; }
        public int? SoCtHienTai { set; get; }
        public int? SoKyTu0 { set; get; }
        public int? SoCtPrefix { set; get; }
        public int? SoCtSuffix { set; get; }
        public int? NgoaiTeId { set; get; }
        public int? SoLien { set; get; }
        public string? MaCtIn { set; get; }
        public int? SttInBangKe { set; get; }
        public int? TkThueGTGT { set; get; }
        public bool? IsMaTuDo { set; get; }
        public bool? IsMaVuViec { set; get; }
        public bool? IsBpBanHang { set; get; }
        public int? SoLuongLoc { set; get; }
        public bool? IsTrungSoCt { set; get; }
        public bool? IsTenNguoiGiaoDich { set; get; }
        public bool? IsNgayLapCt { set; get; }
        public bool? IsLocNguoiDung { set; get; }
        public string? Loai { set; get; }
        public bool? IsChon { set; get; }
        public bool? IsMaPhi { set; get; }
        public string? KyHieuMauHD { set; get; }
        public bool? IsThanhPham { set; get; }
        public bool? IsBoPhanHT { set; get; }
        public bool? IsSuaTien { set; get; }
        public bool? IsMaDieuChinh { set; get; }
        public bool? IsMaTapHopChiPhi { set; get; }
        public bool? IsMaCongTrinh { set; get; }
    }
}
