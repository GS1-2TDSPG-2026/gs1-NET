using System.Reflection;
using Microsoft.OpenApi;
using Phycocarbon.API.Extensions;
using Phycocarbon.API.HostedServices;
using Phycocarbon.Application.Services.Implementations;
using Phycocarbon.Application.Services.Interfaces;
using Phycocarbon.Infrastructure.Messaging;

namespace Phycocarbon.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddPhycocarbonDbContext(builder.Configuration);

        builder.Services
            .AddRepositories();

        builder.Services
            .AddApplicationServices();
        
        builder.Services
            .AddMessagingServices(builder.Configuration);

        builder.Services.AddHostedService<
            MqttTelemetryBackgroundService>();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Phycocarbon API",
                Version = "v1",
                Description =
                    "API REST para monitoramento de biofotorreatores, telemetria IoT, dados orbitais e previsões de IA."
            });

            var xmlFile =
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            var xmlPath =
                Path.Combine(AppContext.BaseDirectory, xmlFile);

            options.IncludeXmlComments(
                xmlPath,
                includeControllerXmlComments: true);
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MobilePolicy", policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                "Phycocarbon API v1");

            options.RoutePrefix = "";
        });

        app.UseCors("MobilePolicy");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}