using System.Collections.Generic;

namespace Eva.Catalog.Api.Platform.Responses;

public sealed record ApiResponse<T>(
    T Data,
    string? TraceId = null
);