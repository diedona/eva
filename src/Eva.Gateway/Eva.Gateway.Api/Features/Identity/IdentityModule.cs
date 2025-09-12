using Eva.Gateway.Api.Features.Identity.LoggedInfo;
using Eva.Gateway.Api.Features.Identity.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Eva.Gateway.Api.Features.Identity;

public static class IdentityModule
{
    public static void AddIdentityEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("identity");

        group.MapPost("/login", LoginHandler.HandleAsync);
        group.MapGet("/me", LoggedInfoHandler.HandleAsync);
    }
}
