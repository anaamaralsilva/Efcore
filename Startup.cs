using System;
using System.Collections.Generic;
using System.IO;
using System.Linq ;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder ;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging ;
using Microsoft.OpenApi.Models;
using Efcore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Efcore
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
            services.AddDbContext<PedidoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            //adicionamos o servidor do swagger
            services.AddSwaggerGen();

            //Adicionamos as informaçoes gerais da API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Loja API",
                    Description = "Uma loja simples para aprender ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ana Carolina",
                        Email = "anacarolina@gmail.com" ,
                        Url = new Uri("https://twitter.com/anacarolina"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Open License",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
