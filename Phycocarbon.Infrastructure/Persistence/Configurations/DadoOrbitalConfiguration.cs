using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class DadoOrbitalConfiguration : IEntityTypeConfiguration<DadoOrbital>
{
    public void Configure(EntityTypeBuilder<DadoOrbital> b)
    {
        b.ToTable("TB_DADO_ORBITAL");

        b.HasKey(d => d.IdDadoOrbital);

        b.Property(d => d.IdDadoOrbital)
            .HasColumnName("id_dado_orbital");

        b.Property(d => d.Fonte)
            .HasColumnName("fonte")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(d => d.DtColeta)
            .HasColumnName("dt_coleta");

        b.Property(d => d.IrradianciaPar)
            .HasColumnName("irradiancia_par")
            .HasPrecision(10, 2);

        b.Property(d => d.Nebulosidade)
            .HasColumnName("nebulosidade")
            .HasPrecision(5, 2);

        b.Property(d => d.TemperaturaAmbiente)
            .HasColumnName("temperatura_ambiente")
            .HasPrecision(4, 2);

        b.Property(d => d.Latitude)
            .HasColumnName("latitude")
            .HasPrecision(10, 7);

        b.Property(d => d.Longitude)
            .HasColumnName("longitude")
            .HasPrecision(10, 7);

        b.Property(d => d.IdFazenda)
            .HasColumnName("id_fazenda");

        b.HasOne(d => d.Fazenda)
            .WithMany(f => f.DadosOrbitais)
            .HasForeignKey(d => d.IdFazenda);
    }
}
