using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //terminal middleware: middleware cuoi cung trong pipeline
            app.Run(async context => { });
        }
    }
}