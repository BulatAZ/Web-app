namespace RequestAccounting3
{
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using RequestAccounting3.Areas.Implimentation;
    using RequestAccounting3.Areas.Interfaces;
    using RequestAccounting3.Areas.Logger;
    using RequestAccounting3.Models;

    public class Startup
    {
        //опционально в Startup можно определить конструктор класса и метод ConfigureServices().
        //При запуске приложения сначала срабатывает конструктор, затем метод ConfigureServices() 
        //и в конце метод Configure(). Эти методы вызываются средой выполнения ASP.NET.
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        // регистрирует сервисы, которые используются приложением.
        // чтобы использовать некоторые сервисы, их вначале надо зарегистрировать. 
        public void ConfigureServices(IServiceCollection services)
        {
            // добавляем контекст RequestContext в качестве сервиса в приложение
            services.AddDbContext<RequestDBContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("RequestsDBConnection")));
            
            // контекст User для работы с пользователями
            services.AddDbContext<UserDBContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("UsersDBConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserDBContext>();
            // метод внедрения зависимостей
            services.AddTransient<IRequestManager, RequestManager>();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IRolesManager, RolesManager>();

            //подключаем сервис MVC, предоставляется возможность работы с ним
            services.AddMvc();
        }

        //Метод Configure устанавливает, как приложение будет обрабатывать запрос.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            /*Таким образом, если имя среды имеет значение "Development", то есть приложение находится
            в состоянии разработки, то при ошибке разработчик увидит детальное описание ошибки. 
            Если же приложение развернуто на хостинге и соответственно имеет другое имя хостирующей среды, 
            то простой пользователь при ошибке ничего не увидит*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.LogInformation("is development true");               
            }
            else
            {                
                app.UseExceptionHandler("/error");
                logger.LogInformation("is development false");
            }
           
            app.UseStaticFiles();
            app.UseAuthentication();
            
            app.UseMvcWithDefaultRoute();
            /*app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });*/
        }
    }
}
