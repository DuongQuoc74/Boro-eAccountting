﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace tamkhoatech.ACWeb.Entities
{
    public class PhieuChiCT : FullAuditedEntity<int>
    {
        public int? PhieuChiId { get; set; }
        public PhieuChi? PhieuChi { get; set; }
        public int? HoaDonDichVuId { get; set; }
        public int? HoaDonChiId { get; set; }
        public string? SoCt { get; set; }
        public DateTime? NgayHd { get; set; }
        public int? NgoaiTeId { get; set; }
        public decimal? TyGia { get; set; }
        public int? GhiNoTk { get; set; }
        public int? KhachHangId { get; set; }
        public decimal? TienTrenHd { get; set; }
        public decimal? TienTrenHdVND { get; set; }
        public decimal? DaTt { get; set; }
        public decimal? DaTtVND { get; set; }
        public decimal? ConPhaiTt { get; set; }
        public decimal? ConPhaiTtVND { get; set; }
        public decimal? PsNo { get; set; }
        public decimal? PsNoVND { get; set; }
        public int? LoaiThue { get; set; }
        public int? MaThue { get; set; }
        public decimal? ThueSuat { get; set; }
        public decimal? Thue { get; set; }
        public decimal? ThueVND { get; set; }
        public decimal? ThanhToan { get; set; }
        public decimal? ThanhToanVND { get; set; }
        public decimal? ThanhToanQd { get; set; }
        public decimal? TyGiaGS { get; set; }
        public string? DienGiai { get; set; }
        public string? DienGiai2 { get; set; }
        public decimal? TienHt { get; set; }
        public string? SoHd { get; set; }
        public string? SoSeri { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? VuViecId { get; set; }
        public int? MaPhiId { get; set; }
        public int? BoPhanHTId { get; set; }
        public int? VatTuId1 { get; set; }
        public int? MaTD01 { get; set; }
        public DateTime? NgayTD01 { get; set; }
        public decimal? SoLuongTD01 { get; set; }
        public string? GhiChuTD01 { get; set; }
        public int? MaTD02 { get; set; }
        public DateTime? NgayTD02 { get; set; }
        public decimal? SoLuongTD02 { get; set; }
        public string? GhiChuTD02 { get; set; }
        public int? MaTD03 { get; set; }
        public DateTime? NgayTD03 { get; set; }
        public decimal? SoLuongTD03 { get; set; }
        public string? GhiChuTD03 { get; set; }
        public int? MauHDId { get; set; }
        public string? MauHDUd { get; set; }
        public string? KiHieuMauHD { get; set; }
        public int? DieuChinhThueTNDNId { get; set; }

    }
}
