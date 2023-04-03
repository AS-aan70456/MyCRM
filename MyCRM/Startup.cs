using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCRM.Domain;
using MyCRM.Domain.Reposetory.interfeises;
using MyCRM.Domain.Reposetory.RepModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM{
    public class Startup{

        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnv){
             Configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("DBSettings.json").Build(); ;
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllUsers, UsersReposetory>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddAuthentication("Cookie").AddCookie("Cookie", config => {
                config.LoginPath = "/Account/Login";
            });
            services.AddAuthorization();


            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //{ ID ?}
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("defult", "{controller=Home}/{action=Home}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Categories}/{action=Categories}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Detail_record}/{action=Detail_record}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=History}/{action=History}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Login}/{action=Login}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Planning}/{action=Planning}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Profile}/{action=Profile}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Record}/{action=Record}/{id?}");
                endpoints.MapControllerRoute("defult", "{controller=Account}/{action=Register}/{id?}");
            });
        }
    }
}
