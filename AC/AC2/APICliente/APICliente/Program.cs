using APICliente.Repositorio;
using APICliente;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using APICliente.Data;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace APICliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creamos y ejecutamos el host
            CreateHostBuilder(args).Build().Run();
        }

        // Este es el punto de entrada principal que configura y arranca la aplicación
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        var configuration = context.Configuration;

                        // Agregar DbContext
                        services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                        // Agregar AutoMapper
                        IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
                        services.AddSingleton(mapper);
                        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                        // Registrar Repositorios
                        services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
                        services.AddScoped<IUserRepositorio, UserRepositorio>();
                        //services.AddScoped<ITrabajadorRepositorio, TrabajadorRepositorio>();
                        //services.AddScoped<IVentaRepositorio, VentaRepositorio>();

                        // Configurar autenticación con JWT
                        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(
                                        System.Text.Encoding.ASCII.GetBytes(
                                            configuration.GetSection("AppSettings:Token").Value)),
                                    ValidateIssuer = false,
                                    ValidateAudience = false
                                };
                            });

                        // Configurar Swagger
                        services.AddSwaggerGen(c =>
                        {
                            c.OperationFilter<SecurityRequirementsOperationFilter>();
                            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                            {
                                Description = "Autorización estándar. Usar Bearer. Ejemplo: \"bearer {token}\"",
                                In = ParameterLocation.Header,
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer"
                            });
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIClientes", Version = "v1" });
                        });

                        // Habilitar CORS
                        services.AddCors();

                        // Agregar controladores
                        services.AddControllers();
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIClientes v1"));
                        }

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        // Habilitar CORS
                        app.UseCors(x => x.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());

                        // Habilitar autenticación y autorización
                        app.UseAuthentication();
                        app.UseAuthorization();

                        // Configurar endpoints
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}