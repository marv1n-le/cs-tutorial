using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CS13_Middleware.Middleware
{
    public static class UseFirstMiddlewareMethod
    {
        //phuong thuc mo rong IApplicationBuilder
        public static void UseFirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}