using System.Collections.Generic;

namespace DarkDhamon.Common.API.Models
{
    public class PagedApiResponse<T> : ApiResponse
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int NumPerPage { get; set; }
        public int TotalPages { get; set; }
    }
}