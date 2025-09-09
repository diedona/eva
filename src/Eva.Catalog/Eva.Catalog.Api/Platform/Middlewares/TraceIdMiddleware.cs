using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Eva.Catalog.Api.Platform.Filters;

public sealed class TraceIdMiddleware
{
    private const string X_REQUEST_ID = "X-Request-Id";
    private static readonly ActivitySource Source = new(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name!);

    private readonly RequestDelegate _next;
    private readonly ILogger<TraceIdMiddleware> _log;

    public TraceIdMiddleware(
        RequestDelegate next,
        ILogger<TraceIdMiddleware> log
    )
    {
        _next = next;
        _log = log;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = Activity.Current?.TraceId.ToString() ?? context.TraceIdentifier;

        if (context.Request.Headers.TryGetValue(X_REQUEST_ID, out var incomingTraceId))
        {
            try
            {
                var parsedTraceId = ActivityTraceId.CreateFromString(incomingTraceId.ToString().AsSpan());

                var ctx = new ActivityContext(
                    parsedTraceId,
                    ActivitySpanId.CreateRandom(),
                    ActivityTraceFlags.Recorded);

                var activity = Source.StartActivity("IncomingRequest", ActivityKind.Server, ctx);

                if (activity is not null)
                {
                    Activity.Current = activity;
                    traceId = parsedTraceId.ToString();
                }
            }
            catch (Exception ex)
            {
                _log.LogError(
                    ex,
                    @"
                        Error while trying to convert incoming trace id: {incomingTraceId}.
                        Using trace id: {currentTraceId}
                    ",
                    incomingTraceId.ToString(),
                    traceId
                );
            }
        }

        // Add the trace ID to the response header
        context.Response.Headers.Append(X_REQUEST_ID, traceId);

        await _next(context);
    }
}
