using System.Collections.Generic;

namespace DarkDhamon.Common.API.Models
{
    public class PagedApiResponse<T> : ApiResponse
    {
        private List<T>? _data;

        public List<T> Data
        {
            get => _data??=new List<T>();
            set => _data = value;
        }

        public int Page { get; set; }
        public int NumPerPage { get; set; }
        public int TotalPages { get; set; }
    }
}