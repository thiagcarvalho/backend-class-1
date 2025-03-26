namespace PetShop.Manager.WebApi.Middlewares
{
    public class CustomReponseHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomReponseHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // That code runs before action
            context.Response.Headers["Custom-Header"] = $"PetShop.Manager::{Guid.NewGuid().ToString()}";

            await _next(context);

            // That code runs after action
        }
    }
}
