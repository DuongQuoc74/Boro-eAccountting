using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.DTO.Common
{
    public class DataApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
