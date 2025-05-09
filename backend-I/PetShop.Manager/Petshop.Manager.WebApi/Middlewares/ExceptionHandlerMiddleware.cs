using PetShop.Manager.Application.Exceptions;

namespace PetShop.Manager.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // That code runs before action
            Console.WriteLine($"{context.Request} initiated...");

            try
            {
                await _next(context); // ... Controller/Action
            }
            catch (ResourceNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Message = "Resource not found",
                        TraceId = context.TraceIdentifier
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        Message = "Oops... something went wrong. ",
                        TraceId = context.TraceIdentifier
                    });
            }

            // That code runs after action
            Console.WriteLine($"{context.Request} finished...");
        }
    }
}
