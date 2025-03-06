
namespace WebAPI.Middlewares
{
    public class GlobalExceptionHandlingMw : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMw> _logger;

      
        public GlobalExceptionHandlingMw(ILogger<GlobalExceptionHandlingMw> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                _logger.LogDebug($"Request path{context.Request.Path}");
                Console.WriteLine($"Request path{context.Request.Path}");
                await next(context);
                Console.WriteLine($"Response {context.Response.StatusCode}");
                if (context.Response.StatusCode == 400)
                    _logger.LogError(context.Response.Body.ToString());
                

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
