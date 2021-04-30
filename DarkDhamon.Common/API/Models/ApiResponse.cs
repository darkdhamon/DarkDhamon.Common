using System;
using System.Text;

namespace DarkDhamon.Common.API.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
    }

    public class ApiResponse<T>:ApiResponse
    {
        public T Data { get; set; }
    }
}
