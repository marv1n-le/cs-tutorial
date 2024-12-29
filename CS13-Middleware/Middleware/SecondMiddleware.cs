using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CS13_Middleware.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/second")
            {
                //phai thiet lap header truoc khi viet noi dung
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (dataFromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cap");
                var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (dataFromFirstMiddleware != null)
                    await context.Response.WriteAsync((string)dataFromFirstMiddleware);
                await next(context);
            }
        }
    }
}