using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Response
{
    public class Response
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }

        public static Response<T> Success(T? data, string message = null)
        {
            return new Response<T> { Data = data, Succeeded = true, Message = message };
        }

        public static Response<T> Fail(string message)
        {
            return new Response<T> { Succeeded = false, Message = message };
        }
    }

}
