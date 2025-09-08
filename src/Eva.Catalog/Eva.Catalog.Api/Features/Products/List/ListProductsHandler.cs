using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Eva.Catalog.Api.Features.Products.List;

public sealed class ListProductsHandler
{
    public static async Task<Results<NoContent, BadRequest>> HandleAsync()
    {
        return TypedResults.NoContent();
    }
}

