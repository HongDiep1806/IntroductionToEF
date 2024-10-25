using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using IntroductionToEF.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntroductionToEF.HostCommon.Middleware
{
    public class APIRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<APIRequestMiddleware> _logger;

        public APIRequestMiddleware(RequestDelegate next, ILogger<APIRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Start middleware 3");

            context.Request.EnableBuffering();

            var IpUserAddress = context.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation($" IP User Address : {IpUserAddress}");

            string requestBody;
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();

                context.Request.Body.Position = 0;
            }

            var logInfo = new RequestLogInfo
            {
                Method = context.Request.Method,
                Protocol = context.Request.Protocol,
                Path = context.Request.Path,
                Host = context.Request.Host.ToString(),
                Headers = context.Request.Headers.ToString(),
                Body = requestBody
            };

            _logger.LogInformation("Request Information: {@LogInfo}", logInfo);

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
            }

            string responseBody;
            using (var reader = new StreamReader(context.Response.Body, Encoding.UTF8, leaveOpen: true))
            {
                responseBody = await reader.ReadToEndAsync();

                context.Response.Body.Position = 0;
            }

            _logger.LogInformation("Back to middleware 3");
        }
    }
}