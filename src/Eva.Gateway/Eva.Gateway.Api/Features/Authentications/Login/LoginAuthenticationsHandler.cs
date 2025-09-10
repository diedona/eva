using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Eva.Gateway.Api.Features.Authentications.Login;

public static class LoginAuthenticationsHandler
{
    public static async Task HandleAsync(
        HttpContext context,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
    }
}
