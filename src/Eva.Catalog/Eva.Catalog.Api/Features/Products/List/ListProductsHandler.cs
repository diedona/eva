using System;
using System.Threading.Tasks;
using Eva.Catalog.Api.Features.Products.List;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

public sealed class ListProductsHandler
{
    public static async Task<Results<NoContent, BadRequest>> HandleAsync()
    {
        return TypedResults.NoContent();
    }
}

