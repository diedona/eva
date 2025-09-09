using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Eva.Catalog.Api.Platform.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace Eva.Catalog.Api.Features.Products.List;

public sealed class ListProductsHandler
{
    public static async Task<
        Results<Ok<ApiResponse<List<ProductsListResponse>>>, NotFound>
    > HandleAsync(
        HttpContext context,
        CancellationToken ctoken,
        ILogger<ListProductsHandler> log
    )
    {
        var products = new List<ProductsListResponse>()
        {
            new(Guid.NewGuid(), "Batata"),
            new(Guid.NewGuid(), "Arroz"),
        };

        return TypedResults.Ok(products.ToApiResponse());
    }
}
