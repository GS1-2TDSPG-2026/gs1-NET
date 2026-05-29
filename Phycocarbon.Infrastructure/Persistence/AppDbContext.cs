using Microsoft.EntityFrameworkCore;
using Phycocarbon.Domain.Entities;


namespace Phycocarbon.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Perfil> Perfis { get; set; }

    public DbSet<Fazenda> Fazendas { get; set; }

    public DbSet<Tanque> Tanques { get; set; }

    public DbSet<DispositivoIot> DispositivosIot { get; set; }

    public DbSet<MetricaTanque> MetricasTanque { get; set; }

    public DbSet<AlertaCritico> AlertasCriticos { get; set; }

    public DbSet<DadoOrbital> DadosOrbitais { get; set; }

    public DbSet<PrevisaoIa> PrevisoesIa { get; set; }
}