namespace DarkDhamon.Common.API.Models;

public class PagedApiResponse<T> : ApiResponse
{
    public List<T> Data { get; set; } = new();
    public int Page { get; set; }
    public int NumPerPage { get; set; }
    public int TotalPages { get; set; }
}