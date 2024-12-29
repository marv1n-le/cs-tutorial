using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CS13_Middleware.Middleware
{
    public class FirstMiddleware
    {
        // RequestDelegate la 1 delegate nhan vao HttpContext va tra ve Task
        private readonly RequestDelegate _next;
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        // Invoke la phuong thuc thuc thi middleware 
        // HttpContext la doi tuong chua thong tin cua Request va Response
        // HttpContext di qua cac middleware
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            context.Items.Add("DataFirstMiddleware", $"<p>URL: {context.Request.Path}</p>");
            // await context.Response.WriteAsync($"<p>URL: {context.Request.Path}</p>");
            await _next(context);
        }
    }
}