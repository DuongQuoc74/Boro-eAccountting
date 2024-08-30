using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class PhieuXuatDcKhoCtDto: EntityDto<int>
    {
        public int? PhieuXuatDcKhoId {set;get;}
      public int? VatTuId {set;get;}
      public string? VatTuUd{set;get;}
      public string? VatTuNm{set;get;}
      public string? DonViTinh { set;get;}
      public DateTime? NgayLo {set;get;}
      public string? SoLo {set;get;}
      public decimal? SoLuong {set;get;}
      public decimal? TonKho {set;get;}
      public decimal? Gia {set;get;}
      public decimal? GiaVND {set;get;}
      public decimal? Tien {set;get;}
      public decimal? TienVND {set;get;}
      public int? GhiNoTK {set;get;}
      public string? GhiNoTKUd {set;get;}
      public int? GhiCoTK {set;get;}
      public string? GhiCoTKUd {set;get;}
      public int? MaPhiId {set;get;}
      public string? MaPhiUd {set;get;}
      public int? VuViecId {set;get;}
      public int? BoPhanHtId {set;get;}
      public int? VatTuId1 {set;get;}
      public int? MaTD01 {set;get;}
      public DateTime? NgayTD01 {set;get;}
      public decimal? SoLuongTD01 {set;get;}
      public string? GhiChuTD01 {set;get;}
      public int? MaTD02 {set;get;}
      public DateTime? NgayTD02 {set;get;}
      public decimal? SoLuongTD02 {set;get;}
      public string? GhiChuTD02 {set;get;}
      public int? MaTD03 {set;get;}
      public DateTime? NgayTD03 {set;get;}
      public decimal? SoLuongTD03 {set;get;}
      public string? GhiChuTD03 {set;get;}
      public int? DieuChinhThueTNDNId {set;get;}
    }
}
