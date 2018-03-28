using Microsoft.AspNetCore.Http;
using SharpRaven;
using SharpRaven.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SentryMiddleware
{
    public class SentryExceptionHandler
    {
        RequestDelegate next;
        RavenClient ravenClient;

        public SentryExceptionHandler(RequestDelegate next, RavenClient ravenClient) {
            this.next = next;
            this.ravenClient = ravenClient;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await next(context);
            } catch (Exception ex) {
                await ravenClient.CaptureAsync(new SentryEvent(ex));

                throw; // Rethrow to pass the exception to other middleware
            }
        }
    }
}
