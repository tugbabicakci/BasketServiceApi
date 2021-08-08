using System.Collections.Generic;
using BasketService.Api.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace BasketService.Api
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
            services.AddDbContext<BasketContext>(opt => opt.UseInMemoryDatabase("BasketDb"));

            services.AddScoped<StockService>();
            services.AddScoped<ProductService>();
            services.AddScoped<Service.BasketService>();

            services.AddControllers()
                .AddNewtonsoftJson();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Basket Service",
                        Description = "Basket Service",
                        Version = "",
                        Contact = new OpenApiContact
                        {
                            Name = "Tugba Býçakcý",
                            Email = "",
                        }
                    }
                );

                c.IncludeXmlComments(PlatformServices.Default.Application.ApplicationBasePath + "BasketService.Api.xml");

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket Service Api");
                    c.RoutePrefix = "";
                });

            app.UseEndpoints(x => x.MapControllers());

        }
    }
}