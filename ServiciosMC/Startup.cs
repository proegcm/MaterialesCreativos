using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiciosMC.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiciosMC
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
           {
               config.Cookie.Name = "MCUser";
               config.LoginPath = new PathString("/Login");
               config.Events.OnRedirectToLogin = context =>
               {
                   if (context.Request.Path.StartsWithSegments("/CreacionClienteCODInterno"))
                   {
                       var redirecthPath = new Uri(context.RedirectUri);
                       context.Response.Redirect(new PathString("/LoginInterno"));

                   }
                   else {
                       context.Response.Redirect(context.RedirectUri);
                   }
                   return Task.CompletedTask;
               };
           });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("USUARIO_ADMIN", policy => policy.RequireClaim("TIPO_USUARIO", "ADMINISTRADOR"));
                options.AddPolicy("USUARIO_NORMAL", policy => policy.RequireClaim("TIPO_USUARIO", "COLABORADOR"));
            });

            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Helper.Enviroment = env.EnvironmentName;
            if (env.EnvironmentName == "Production")
            {
                Helper.config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            }
            else
            {
                Helper.config = new ConfigurationBuilder().AddJsonFile($"appsettings.{env.EnvironmentName}.json").Build();
            }

            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {

                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            
        }
    }

        }
    

