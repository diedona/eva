using Eva.Catalog.Api.Features.Products;
using Eva.Catalog.Api.Platform.Filters;
using Eva.Catalog.Api.Platform.Telemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, config) => config.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddOpenTelemetryWithConfiguration(builder);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.UseMiddleware<TraceIdMiddleware>();

app.UseHttpsRedirection();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Eva Catalog v1");
});

app.AddProductsEndpoints();

app.Run();
