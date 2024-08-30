using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace tamkhoatech.ACWeb.Entities
{
    public class SoPhuSupport : BasicAggregateRoot<int?>
    {
        public string? TenNganHang {  get; set; }
        public string? DienGiai {  get; set; }
        public string? TenNgay {  get; set; }
        public string? TenDienGiai {  get; set; }
        public string? TenGhiNo {  get; set; }
        public string? TenGhiCo {  get; set; }
        public string? TenSoTaiKhoan {  get; set; }
    }
}
