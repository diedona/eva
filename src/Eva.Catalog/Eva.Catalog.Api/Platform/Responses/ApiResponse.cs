namespace Eva.Catalog.Api.Platform.Responses;

public sealed record ApiResponse<T>(
    T Data
);