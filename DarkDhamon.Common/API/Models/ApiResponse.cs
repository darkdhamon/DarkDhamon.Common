namespace DarkDhamon.Common.API.Models;

public class ApiResponse
{
    public int RequestId { get; set; }
    public string? Message { get; set; }

    public ApiResponse()
    {
        
    }

    public ApiResponse(ApiRequest apiRequest)
    {
        For(apiRequest);
    }

    public void For(ApiRequest apiRequest)
    {
        RequestId = apiRequest.RequestId;
    }
}
