using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace ContosoUniversity.API
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
            // CONFIGURACIÓN DEL SERVICIO DE AUTENTICACIÓN JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:ClaveSecreta"])
                        )
                    };
                });
            // REGISTRAMOS SWAGGER COMO SERVICIO
            services.AddOpenApiDocument(document =>
            {
                document.Title = "Título del Web API";
                document.Description = "Descripción del Web API.";

                // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
                // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
                    }
                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            services.AddDbContext<SchoolContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // AÑADIMOS EL MIDDLEWARE DE AUTENTICACIÓN
            // DE USUARIOS AL PIPELINE DE ASP.NET CORE
            app.UseAuthentication();

            // AÑADIMOS EL MIDDLEWARE DE SWAGGER (NSwag)
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();           
            app.UseMvc();
        }
    }
}
