using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Eva.Catalog.Api.Core.Telemetry;

public static class OpenTelemetryExtensions
{
    public static void AddOpenTelemetryWithConfiguration(this IServiceCollection services)
    {
        services
            .AddOpenTelemetry()
            .WithTracing(tracing =>
            {
                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .SetResourceBuilder(
                        ResourceBuilder.CreateDefault().AddService("Eva.Catalog.Api")
                    )
                    .AddOtlpExporter()
                    .AddConsoleExporter();
            })
            .WithMetrics(metricsProviderBuilder =>
            {
                metricsProviderBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            });
    }
}
