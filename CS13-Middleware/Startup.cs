using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS13_Middleware.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CS13_Middleware
{
    public class Startup
    {
    /*
 * middleware la 1 module code nhan yeu cau gui den Request va tra ve Response
 * pipeline la 1 chuoi cac middleware
 * pipeline : M1
 */
        public void ConfigureServices(IServiceCollection services)
        {
            // Phai dang ki middleware de su dung duoc boi vi no la 1 service
            services.AddTransient<SecondMiddleware>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseFirstMiddleware();
            app.UseSecondMiddleware();
            app.UseRouting(); //dieu huong request den controller nhu la Get, Post, Put, Delete
            app.UseEndpoints(endpoints =>
            {   //endpoints la 1 doi tuong chua cac phuong thuc mo rong
                //endpoint1
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("Trang gioi thieu!");
                });
                //endpoint2
                endpoints.MapGet("/contact", async context =>
                {
                    await context.Response.WriteAsync("Trang lien he!");
                });
                //re nhanh pipeline
                app.Map("/admin", app1 =>
                {
                    // Tao middle ware cua nhanh
                    app1.UseRouting();
                    app1.UseEndpoints(ep =>
                    {
                        ep.MapGet("/dashboard", async context =>
                        {
                            await context.Response.WriteAsync("Trang quan tri!");
                        });
                    });
                });
            });
            //app.UseMiddleware<FirstMiddleware>();
            //terminal middleware: middleware cuoi cung trong pipeline
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from the terminal middleware");
            });
        }
    }
}

/*
 * pipeline: StaticMiddleware -> FirstMiddleware -> SecondMiddleware -> EndpointRoutingMiddleware -> terminal middleware
*/