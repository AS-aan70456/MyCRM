using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRM{
    public class Startup{

        //public IConfiguration Configuration { get; }
        //public Startup(IHostEnvironment hostEnv){
        //    Configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("DBSettings.json").Build(); ;
        //}

        public void ConfigureServices(IServiceCollection services){
            // services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<IallCategory, CategoryReposetory>();
            //services.AddTransient<IallGameItem, GameItemReposetory>();
            //services.AddTransient<IallComments, CommentsReposetory>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp =>)

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            //{ ID ?}
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("defult", "{controller=Home}/{action=Home}/{id?}");
            });
        }
    }
}
