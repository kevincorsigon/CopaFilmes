using System;
using CopaFilmes.Api.Controllers;
using CopaFilmes.ApplicationService;
using CopaFilmes.ApplicationService.Interfaces;
using CopaFilmes.Infra;
using CopaFilmes.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFilmeService, FilmeService>();
            services.AddTransient<ICampeonatoApplicationService, CampeonatoApplicationService>();
            services.AddTransient<IFilmeApplicationService, FilmeApplicationService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Copa de Filmes",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.0",
                        Contact = new OpenApiContact
                        {
                            Name = "Kevin Corsini Goncalves",
                            Url = new Uri("https://www.linkedin.com/in/kevin-corsini-gon%C3%A7alves-0952a36b/")
                        }
                    });
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Copa de Filmes V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
