using Eva.Catalog.Api.Features.Products.List;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Eva.Catalog.Api.Features.Products;

public static class ProductsModule
{
    public static void AddProductsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("products");

        group.MapGet("/", ListProductsHandler.HandleAsync);
    }
}
