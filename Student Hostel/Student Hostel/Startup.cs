using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Student_Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
      
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//添加操作数据库的服务  
        { 
            services.AddMvc();
            services.AddTransient<IStudentService, StudentService>();//StudentService的实例化对象给IStudentService
            services.AddTransient<DormitoryService>();
            services.AddTransient<SysUserService>();
            services.AddTransient<StuUserService>();
            services.AddTransient<RegisterService>();
            var connStr = _configuration.GetConnectionString("ConnStr");
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connStr));
            services.AddSession();

      
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();//使用个静态文件

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>//定义路由规则
            {

                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");//模式

            });

        }
    }
}
