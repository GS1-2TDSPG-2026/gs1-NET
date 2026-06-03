using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Implementations;
using Phycocarbon.Application.Services.Interfaces;
using Phycocarbon.Infrastructure.Persistence;
using Phycocarbon.Infrastructure.Persistence.Repositories;

namespace Phycocarbon.API.Extensions;

public static class PhycocarbonServiceCollectionExtensions
{
    public static IServiceCollection AddPhycocarbonDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("OracleDb")
            ?? throw new InvalidOperationException(
                "Connection string OracleConnection não encontrada.");

        services.AddDbContext<PhycocarbonContext>(options =>
            options.UseOracle(connectionString));

        return services;
    }
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<
            IAlertaCriticoRepository,
            AlertaCriticoRepository>();

        services.AddScoped<
            IDadoOrbitalRepository,
            DadoOrbitalRepository>();

        services.AddScoped<
            IDispositivoIotRepository,
            DispositivoIotRepository>();

        services.AddScoped<
            IMetricaTanqueRepository,
            MetricaTanqueRepository>();

        services.AddScoped<
            IPrevisaoIaRepository,
            PrevisaoIaRepository>();

        services.AddScoped(
            typeof(IRepository<>),
            typeof(Repository<>));

        return services;
    }
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<
            IAlertaCriticoService,
            AlertaCriticoService>();

        services.AddScoped<
            IDadoOrbitalService,
            DadoOrbitalService>();

        services.AddScoped<
            IDispositivoIotService,
            DispositivoIotService>();

        services.AddScoped<
            IMetricaTanqueService,
            MetricaTanqueService>();

        services.AddScoped<
            IPrevisaoIaService,
            PrevisaoIaService>();

        return services;
    }
}