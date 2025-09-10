using Eva.Gateway.Api.Features.Authentications.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Eva.Gateway.Api.Features.Authentications;

public static class AuthenticationsModule
{
    public static void AddAuthenticationsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("authentications");

        group.MapGet("/login", LoginAuthenticationsHandler.HandleAsync);
    }
}
