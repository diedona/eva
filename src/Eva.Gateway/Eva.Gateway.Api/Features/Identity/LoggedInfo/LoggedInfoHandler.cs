using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Eva.Gateway.Api.Features.Identity.LoggedInfo;

public static class LoggedInfoHandler
{
    public static async Task<Results<
        Ok<string>,
        BadRequest
    >> HandleAsync(
        HttpContext context,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok("Oh, i don't know you yet...");
    }
}
