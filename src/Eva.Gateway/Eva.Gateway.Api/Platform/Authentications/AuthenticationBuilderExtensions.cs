using System;
using System.Text;
using Eva.Gateway.Api.Platform.Configurations.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Eva.Gateway.Api.Platform.Authentications;

public static class AuthenticationBuilderExtensions
{
    public static AuthenticationBuilder AddConfiguredJwtBearer(
        this AuthenticationBuilder builder,
        IConfiguration configuration
    )
    {
        var jwtOptions = configuration
            .GetSection(JwtOptions.SectionName)
            .Get<JwtOptions>() ?? throw new ArgumentNullException(JwtOptions.SectionName);

        return builder.AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
            };
        });
    }
}
