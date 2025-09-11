using Eva.Catalog.Api.Platform.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Eva.Catalog.Api.Platform.Adapters;

public static class HttpResultAdapter
{
    public static Ok<ApiResponse<T>> Ok<T>(T data)
        => TypedResults.Ok(new ApiResponse<T>(data));
}
