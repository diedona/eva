using Eva.Gateway.Api.Features.Identity;
using Eva.Gateway.Api.Platform.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("Yarp"));

builder.Host.UseSerilog((ctx, config) =>
    config.ReadFrom.Configuration(ctx.Configuration)
);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddConfiguredJwtBearer(builder.Configuration);

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseHttpsRedirection();

app.MapOpenApi();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.AddIdentityEndpoints();

app.Run();
