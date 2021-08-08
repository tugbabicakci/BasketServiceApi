using System;
using System.Collections.Generic;

namespace MicroserviceTemplate.Api.Model
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; protected set; }

        public string Message { get; protected set; }
        public T Response { get; protected set; }

        public ApiResult(T response, bool isSuccess = true, string message = null)
        {
            Response = response;
            IsSuccess = isSuccess;
            Message = message;
        }

        public ApiResult(T response, List<string> messages, bool isSuccess = false)
        {

            Response = response;
            IsSuccess = isSuccess;
            Message = string.Join(Environment.NewLine, messages);
        }

    }
}