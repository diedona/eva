using Eva.Catalog.Api.Features.Product.List;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Eva.Catalog.Api.Features.Product;

public static class ProductModule
{
    public static void AddProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", ListProductHandler.HandleAsync);
    }
}
