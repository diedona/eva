using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Eva.Gateway.Api.Features.Identity.Login;

public static class LoginHandler
{
    public static async Task HandleAsync(
        HttpContext context,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
    }
}
