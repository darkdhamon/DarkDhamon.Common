using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkDhamon.Common.API.Models
{
    public abstract class ApiRequest
    {
        public int RequestId { get; set; }
    }
    /// <summary>
    /// In cases where multiple request come in from the same client. Use this along with combination with
    /// ApiResponse so that client can match the latest response by RequestId.
    ///
    /// If used copy RequestID to ApiResponse Object
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ApiRequest<TData>:ApiRequest
    {
        public TData? RequestData { get; set; }
    }
}
