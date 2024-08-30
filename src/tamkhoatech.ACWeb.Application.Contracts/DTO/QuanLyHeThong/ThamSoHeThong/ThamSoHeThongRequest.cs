using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace tamkhoatech.ACWeb.Dto
{
    public class ThamSoHeThongRequest
    {
        public int Id { set; get; }
        public string? DienGiai { set; get; }
        public string? GiaTri { set; get; }
    }
}
