using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS.Common
{
    public class ResponResult
    {
     

        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }
        public object? Data { get; private set; }

        public ResponResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
           
        }
        public ResponResult(bool isSuccess, string? message)
        {
            IsSuccess = isSuccess;
            Message = message;
           
        }
        public ResponResult(bool isSuccess, string? message, object? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

    }
}
