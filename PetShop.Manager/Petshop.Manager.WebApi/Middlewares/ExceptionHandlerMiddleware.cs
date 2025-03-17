using Microsoft.AspNetCore.Http;
using System;
using System.Net;


namespace Petshop.Manager.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger){
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context){
            try{
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync (
                    new { 
                        Message = "It happens an error",
                        TraceId = context.TraceIdentifier
                    });

            }
            finally{
                _logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} has been finished!");
            }
        }
    }
}
