using Eva.Catalog.Api.Core.Telemetry;
using Eva.Catalog.Api.Features.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetryWithConfiguration();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Eva Catalog v1");
});

app.AddProductsEndpoints();

app.UseHttpsRedirection();

app.Run();
