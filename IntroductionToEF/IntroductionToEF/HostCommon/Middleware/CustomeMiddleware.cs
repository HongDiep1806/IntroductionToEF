namespace IntroductionToEF.HostCommon.Middleware
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class CustomeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomeMiddleware> _logger;

        public CustomeMiddleware(RequestDelegate next, ILogger<CustomeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            _logger.LogInformation("Start Custome Middleware 1");
            await _next(context);
            _logger.LogInformation("Back to middleware 1");
        }
    }

}
