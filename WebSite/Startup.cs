using CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;


namespace WebSite
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AdminContext>(options =>
            //      options.UseSqlServer(Configuration.GetConnectionString("Context")));

            services.AddMvc();

            services.AddDistributedMemoryCache();

            //services.AddAutoMapper(typeof(ConfigurationProfile).GetTypeInfo().Assembly,
            //    typeof(ConfigurationProfile).GetTypeInfo().Assembly);

            Configuracao.InjecaoDependencia(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                }
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Aluno}/{action=Index}/{id?}");
            });
        }
    }
}
