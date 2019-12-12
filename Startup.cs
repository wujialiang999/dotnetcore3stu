using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetcore3stu
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册服务
            services.AddSingleton<IWelcomeService,WelcomService>();// 单例模式
            // AddTransient 每次请求都声称一个实例
            // AddScoped 一次web请求生成一个实例,多次请求还是一个
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IWelcomeService welcomeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    throw new System.Exception("出错了");
                    var welcome = welcomeService.getMessage();
                    await context.Response.WriteAsync(welcome);
                });
            });
        }
    }
}
