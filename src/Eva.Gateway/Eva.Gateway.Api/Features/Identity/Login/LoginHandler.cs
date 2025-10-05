using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace Eva.Gateway.Api.Features.Identity.Login;

internal static class LoginHandler
{
    public static async Task<Results<
        Ok<string>,
        BadRequest
    >> HandleAsync(
        HttpContext context,
        ILogger<Program> log,
        CancellationToken cancellationToken,
        LoginRequest request
    )
    {
        log.LogInformation("{@request}", request);
        return TypedResults.Ok($"oh, hello there {request.Username} =)");
    }
}
