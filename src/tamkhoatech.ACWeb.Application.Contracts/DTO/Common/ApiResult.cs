using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.Dto.Common
{
    public class ApiResult
    {
        public bool IsSuccessed { get; set; }
        public int? Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
