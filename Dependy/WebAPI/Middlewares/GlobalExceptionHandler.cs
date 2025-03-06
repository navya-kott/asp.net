namespace WebAPI.Middlewares
{
    public class GlobalExceptionHandler 
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next) => _next = next;
       
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request path{context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Response {context.Response.StatusCode}");
        }

    }
}
