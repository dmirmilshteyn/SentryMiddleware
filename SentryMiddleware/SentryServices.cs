using Microsoft.Extensions.DependencyInjection;
using SharpRaven;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentryMiddleware
{
    public static class SentryServices
    {
        public static void AddSentry(this IServiceCollection services, string dsn) {
            if (!string.IsNullOrEmpty(dsn)) {
                services.AddSingleton(options => new RavenClient(dsn));
            }
        }
    }
}
