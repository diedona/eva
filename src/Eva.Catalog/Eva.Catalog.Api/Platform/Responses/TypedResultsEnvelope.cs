using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Eva.Catalog.Api.Platform.Responses;

public static class TypedResultsEnvelope
{
    public static Ok<ApiResponse<T>> OkEnvelope<T>(T data)
        => TypedResults.Ok(data.ToApiResponse());
}
