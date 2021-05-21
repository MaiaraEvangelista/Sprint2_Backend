using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai.Gufi.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services

                //Adiciona os controlles
                .AddControllers()

                //Adiciona os jsons
                .AddNewtonsoftJson(options =>
                {
                    //Ignora os loopings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    //Ignora os valores nulos quando fizermos apresentações de junções
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Adiciona o serviço do Swagger
            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio


            // Registra o gerador Swagger, definindo 1 ou mais documentações Swagger
            services.AddSwaggerGen(c=> { 
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gufi.webApi", Version = "v1" });

                // Define o caminho de comentários para o  Swagger JSON e UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })



                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // define que o issuer será validado
                        ValidateIssuer = true,

                        // define que o audience será validado
                        ValidateAudience = true,

                        // define que o tempo de vida será validado
                        ValidateLifetime = true,

                        // forma de criptografia e a chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao")),

                        // verifica o tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde está vindo
                        ValidIssuer = "gufi.webApi",

                        // define o nome da audience, para onde está indo
                        ValidAudience = "gufi.webApi"
                    };
                });


            services
                // Define a forma de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // define que o issuer será validado
                        ValidateIssuer = true,

                        // define que o audience será validado
                        ValidateAudience = true,

                        // define que o tempo de vida será validado
                        ValidateLifetime = true,

                        // forma de criptografia e a chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao")),

                        // verifica o tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde está vindo
                        ValidIssuer = "gufi.webApi",

                        // define o nome da audience, para onde está indo
                        ValidAudience = "gufi.webApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Habilitar middleware para servir swagger-ui (HTML, JS, CSS, etc.),
            // Especificando o terminal JSON Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gufi.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Habilita autenticação
            app.UseAuthentication();

            // Habilita autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Segue o mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
