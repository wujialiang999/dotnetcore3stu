using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dotnetcore3stu
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册服务
            var connectionString = _configuration["ConnectionStrings:SQLiteDb"];
            // var connectionString = _configuration.GetConnectionString("SQLiteDb");
            services.AddMvc(options => options.EnableEndpointRouting = false);//.net core 3与2不同
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddSingleton<IWelcomeService, WelcomService>();// 单例模式
            services.AddSingleton<IReposity<Student>, InMertoryRepository>();
            // AddTransient 每次请求都声称一个实例
            // AddScoped 一次web请求生成一个实例,多次请求还是一个
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IWelcomeService welcomeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //非开发环境下使用
                app.UseExceptionHandler();
            }

            // 显示index.html的中间件
            // app.UseDefaultFiles();
            app.UseStaticFiles();
            // app.UseFileServer();
            //UseFileServer包含前两个中间件UseDefaultFiles和UseStaticFiles
            // 使用默认路由的MVC框架
            // app.UseMvcWithDefaultRoute(); //源代码 "{controller=Home}/{action=Index}/{id?}"
            //自定义路由
            app.UseMvc(builder =>
            {
                // /Home/Index/3
                builder.MapRoute("Default", "{controller}/{action}/{id?}");// ?表示可选 按照约定配置路由
            });
            app.UseRouting();
            //判断是否为单元测试环境
            // env.EnvironmentName = "UnionTest";
            // env.IsEnvironment("UnionTest");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var welcome = welcomeService.getMessage();
                    await context.Response.WriteAsync(welcome);
                });
            });
        }
    }
}
