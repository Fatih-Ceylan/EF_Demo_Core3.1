using Business.Services;
using Business.Services.UrunIslemleri;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityCore3._1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddScoped(typeof(IMenuService), typeof(MenuService));
            services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
            services.AddScoped(typeof(IUrunRepository), typeof(UrunRepository));
            services.AddScoped(typeof(IUrunSiparisRepository), typeof(UrunSiparisRepository));
            services.AddScoped(typeof(IUrunIslemleriService), typeof(UrunIslemleriService));
            services.AddMvc();

            //services.AddScoped<IMenuService,MenuService>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<IUrunRepository, UrunRepository>();
            //services.AddScoped<IUrunSiparisRepository, UrunSiparisRepository>();
            //services.AddScoped<IUrunIslemleriService, UrunIslemleriService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
