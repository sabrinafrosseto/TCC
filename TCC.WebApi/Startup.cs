using Core.Business;
using Core.Interfaces.Business;
using Core.Interfaces.Data;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.WebApi
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

            services.AddTransient<MySqlConnection>(_ => new MySqlConnection("Server=localhost;Database=tcc;Uid=root;Pwd=123456;"));

            services.AddTransient<ICategoriaData, CategoriaData>();
            services.AddTransient<ICategoriaBusiness, CategoriaBusiness>();

            services.AddTransient<IAnuncianteData, AnuncianteData>();
            services.AddTransient<IAnuncianteBusiness, AnuncianteBusiness>();

            services.AddTransient<ITagAnuncianteData, TagAnuncianteData>();
            services.AddTransient<ITagAnuncianteBusiness, TagAnuncianteBusiness>();

            services.AddTransient<IEmailAnuncianteData, EmailAnuncianteData>();
            services.AddTransient<IEmailAnuncianteBusiness, EmailAnuncianteBusiness>();

            services.AddTransient<ITelefoneAnuncianteData, TelefoneAnuncianteData>();
            services.AddTransient<ITelefoneAnuncianteBusiness, TelefoneAnuncianteBusiness>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TCC.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCC.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
