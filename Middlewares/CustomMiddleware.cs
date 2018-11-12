using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace MyPOS.Middlewares
{
    public class CustomMiddleware
    {
        public RequestDelegate Next { get; }
        private readonly ILogger<CustomMiddleware> Logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> Logger)
        {
            this.Logger = Logger;
            this.Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;

            // Logging
            Console.WriteLine(path);
         
            Logger.LogInformation($"value of log info: {path}");


            if (!path.StartsWithSegments("/api"))
            {
                // General error handling
                //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //await context.Response.WriteAsync("Invalid Path");
                Console.WriteLine(context.Request.Host.ToString());
                Console.WriteLine(context.Request.Path.ToString());

                string Url = $"https://{context.Request.Host.ToString()}/Product/index";

                context.Response.Redirect(Url, true);
                context.Response.StatusCode = 302;
            }
            else
            {
                await this.Next.Invoke(context);

                /*

                // Authentication and Authorization
                var validKey = false;
                var keyExists = context.Request.Headers.ContainsKey("APIKey");

                if (keyExists)
                {
                    if (context.Request.Headers["APIKey"].Equals("CM1234"))
                    {
                        validKey = true;
                    }
                }

                if (validKey)
                {
                    await this.Next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync("Invalid API Key");
                }

                 */
            }
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
