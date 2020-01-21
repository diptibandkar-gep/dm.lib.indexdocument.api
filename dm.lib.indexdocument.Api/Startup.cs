
using dm.lib.indexdocument.DataAccess.Implementation;
using dm.lib.indexdocument.DataAccess.Interface;
using dm.lib.indexdocument.Service;
using dm.lib.indexdocument.Service.Interface;
using dm.lib.infrastructure.nuget;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace dm.lib.indexdocument.api
{
    public class Startup: GepStartup
    {
        public const string APPLICATION_ID = "12";
        public Startup(IConfiguration configuration):base(configuration,APPLICATION_ID)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddScoped<IIndexDataAccess, IndexDataAccess>();
            services.AddScoped<IIndexService, IndexService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service, IApplicationLifetime applicationLifetime)
        {
            base.Configure(app, env, service, applicationLifetime);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
                });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
