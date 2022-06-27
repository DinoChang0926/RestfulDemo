using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestfulDemo.Data;
using RestfulDemo.Services;
using AutoMapper;
using System;
using System.Net;

namespace RestfulDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupAction => 
                                        setupAction.ReturnHttpNotAcceptable = true
                                    ).AddXmlDataContractSerializerFormatters();
            services.AddControllersWithViews();
            #region 使網站可以儲存後重整不需重開偵錯(需安裝 Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation)
            services.AddMvc().AddRazorRuntimeCompilation();
            #endregion
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddDbContext<AppDbContext>(option => {
                option.UseSqlServer(Configuration["DBContext:ConnectionString"]);
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.WithOrigins("https://localhost:5011",
                                                              "http://test.com")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();               
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
