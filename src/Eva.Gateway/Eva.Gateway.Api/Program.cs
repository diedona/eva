using Eva.Gateway.Api.Features.Identity;
using Eva.Gateway.Api.Platform.Exceptions.Handlers;
using Eva.Gateway.Api.Platform.Extensions;
using Eva.Gateway.Api.Platform.Middlewares;
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

builder.Services.AddOpenTelemetryWithConfiguration(builder);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddConfiguredJwtBearer(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseRouting();

app.UseMiddleware<TraceIdMiddleware>();

app.UseHttpsRedirection();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Eva Catalog v1");
});

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.AddIdentityEndpoints();

app.UseExceptionHandler();

app.Run();
