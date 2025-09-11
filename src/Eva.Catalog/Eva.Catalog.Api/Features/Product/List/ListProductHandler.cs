using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eva.Catalog.Api.Platform.Adapters;
using Eva.Catalog.Api.Platform.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace Eva.Catalog.Api.Features.Product.List;

public sealed class ListProductHandler
{
    public static async Task<
        Results<
            Ok<ApiResponse<IEnumerable<ListProductResponse>>>,
            NotFound
        >
    > HandleAsync(
        HttpContext context,
        CancellationToken cancellationToken,
        ILogger<ListProductHandler> log
    )
    {
        var products = new List<ListProductResponse>()
        {
            new(Guid.NewGuid(), "Batata"),
            new(Guid.NewGuid(), "Arroz"),
        };

        return HttpResultAdapter.Ok(products.AsEnumerable());
    }
}
