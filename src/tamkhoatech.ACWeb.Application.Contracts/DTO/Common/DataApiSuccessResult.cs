using System;
using System.Collections.Generic;
using System.Text;

namespace tamkhoatech.ACWeb.DTO.Common
{
    public class DataApiSuccessResult<T> : DataApiResult<T>
    {
        public DataApiSuccessResult(T data)
        {
            IsSuccessed = true;
            Data = data;
        }
        public DataApiSuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
