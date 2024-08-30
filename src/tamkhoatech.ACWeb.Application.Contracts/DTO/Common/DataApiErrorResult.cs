using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.DTO.Common
{
    public class DataApiErrorResult<T> :DataApiResult<T>
    {
        public DataApiErrorResult()
        {

        }
        public DataApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
    }
}
