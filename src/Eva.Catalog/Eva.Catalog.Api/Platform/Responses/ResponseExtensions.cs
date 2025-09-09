using Microsoft.AspNetCore.Http;

namespace Eva.Catalog.Api.Platform.Responses;

public static class ResponseExtensions
{
    public static ApiResponse<T> ToApiResponse<T>(this T data)
        => new(data);
}
