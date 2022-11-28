namespace DarkDhamon.Common.API.Models;

public class ApiResponse<T>:ApiResponse
{
    public T? Data { get; set; }
}