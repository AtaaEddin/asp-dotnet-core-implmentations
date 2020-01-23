using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Postgres.Data;
using Microsoft.EntityFrameworkCore;
using Postgres.Business.Interfaces;
using Postgres.Web.Services;

namespace Postgres.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PacketContext>(c => {
                c.UseNpgsql(Configuration.GetConnectionString("PacketDbContext"));
            });   

            services.AddScoped(typeof(IEFRepository<>),typeof(EFRepository<>));
            services.AddScoped<PacketRepository>();
            services.AddScoped<PacketService>();   
            services.AddScoped<FeatureService>();   
            services.AddScoped<PacketFeaturesService>();   
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();
            }
                        
            app.UseRouting();
            
            app.UseEndpoints(Endpoint =>
            {
                Endpoint.MapRazorPages();
            });
        }
    }
}
