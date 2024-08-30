﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.DTO.QuanLyHeThong.CapNhatSoDuDauKy.DuDauKyTk
{
    public class DuDauKyTkDto :EntityDto<int?>
    {
        public int? ChiNhanhId { set; get; }
        public string? ChiNhanhNm { set; get; }
        public DateTime? Ngay { set; get; }
        public int? TaiKhoanId { set; get; }
        public string? TaiKhoanUd { set; get; }
        public string? TaiKhoanNm { set; get; }
        public decimal? DuNoDauKy { set; get; }
        public decimal? DuNoDauKyVND { set; get; }
        public decimal? DuCoDauKy { set; get; }
        public decimal? DuCoDauKyVND { set; get; }
        public decimal? DuNoDauNam { set; get; }
        public decimal? DuNoDauNamVND { set; get; }
        public decimal? DuCoDauNam { set; get; }
        public decimal? DuCoDauNamVND { set; get; }
        public bool IsNotTkCongNoOrTkVatTu { set; get; }
    }
}
