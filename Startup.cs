using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace CourseApp
{
    public class Startup
    {
        // using Microsoft.Extensions.Configuration;
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // projede  mvc middleware projete dahil ettik mvc'yi kullanmak için bunu yazmalıyız

            services.AddDbContext<DataContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseDeveloperExceptionPage(); // hata olduğunda hata kodlarını görelim
            app.UseStatusCodePages();  // 404 hatası yada server hatası varsa göstersin

            //wwwroot
            app.UseStaticFiles(); // wwwroot klasörü css,javascript  ile alakalı

            //package.json -- node_modules dahil etmek için yazılan kod 
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider=new PhysicalFileProvider(Path.Combine( Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath=new PathString("/vendor")
            });

            // Controller/action/id?
            app.UseMvcWithDefaultRoute();
        }
    }
}
