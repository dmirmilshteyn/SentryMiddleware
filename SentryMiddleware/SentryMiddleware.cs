using Microsoft.AspNetCore.Builder;
using System;

namespace SentryMiddleware
{
    public static class SentryMiddleware
    {
        public static IApplicationBuilder UseSentryExceptionHandler(this IApplicationBuilder builder) {
            return builder.UseMiddleware<SentryExceptionHandler>();
        }
    }
}
