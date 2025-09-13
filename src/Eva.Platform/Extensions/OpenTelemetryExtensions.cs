using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Eva.Platform.Extensions;

public static class OpenTelemetryExtensions
{
    public static void AddEvaOpenTelemetry(
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
