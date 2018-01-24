using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Ninject;
using Ninject.Modules;
using diplom2.Models;

namespace diplom2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static WebServicesContext db;
        public static IKernel AppKernel = new StandardKernel();

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string connection = Configuration.GetConnectionString("WebServices");
            //var optionsBuilder = new DbContextOptionsBuilder<WebServicesContext>();
            //optionsBuilder.UseSqlServer(connection);
            //item = new WebServicesContext();

            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("WebServices");
            // добавляем контекст в качестве сервиса в приложение
            services.AddDbContext<WebServicesContext>(options =>
                options.UseSqlServer(connection));

            services.AddMvc();

            var serv = services.ToList();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=LoginForm}/{id?}");
            });
        }
    }
}
