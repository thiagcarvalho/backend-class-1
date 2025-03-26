namespace PetShop.Manager.WebApi.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // That code runs before action
            Console.WriteLine($"{context.Request} initiated...");

            await _next(context); // ... Controller/Action

            // That code runs after action
            Console.WriteLine($"{context.Request} finished...");
        }
    }
}
