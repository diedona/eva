using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Eva.Catalog.Api.Platform.Extensions;

public static class OpenTelemetryExtensions
{
    public static void AddOpenTelemetryWithConfiguration(
        this IServiceCollection services,
        IHostApplicationBuilder builder
    )
        => services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddConsoleExporter()
            );
}
