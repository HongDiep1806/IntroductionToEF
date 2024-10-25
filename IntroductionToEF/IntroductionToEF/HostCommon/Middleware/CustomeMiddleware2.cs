namespace IntroductionToEF.HostCommon.Middleware
{
    public class CustomeMiddleware2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomeMiddleware> _logger;

        public CustomeMiddleware2(RequestDelegate next, ILogger<CustomeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {

            //await context.Response.WriteAsync("<div> before - CustomeMiddleware </div>");
            //await _next(context);
            //await context.Response.WriteAsync("<div> after - CustomeMiddleware </div>");

            _logger.LogInformation("Start Custome Middleware 2");
            await _next(context);
            _logger.LogInformation("Back to middleware 2");
        }
    }
}
