using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Eva.Catalog.Api.Platform.Filters;

public sealed class TraceIdMiddleware
{
    private readonly RequestDelegate _next;

    public TraceIdMiddleware(
        RequestDelegate next
    )
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier;

        // Optionally, check if a header for tracing was passed in
        if (context.Request.Headers.TryGetValue("X-Trace-Id", out var incomingTraceId))
        {
            traceId = incomingTraceId.ToString();
            context.TraceIdentifier = traceId; // Override with the incoming ID
        }

        // Add the trace ID to the response header
        context.Response.Headers.Append("X-Trace-Id", traceId);

        await _next(context);
    }
}
