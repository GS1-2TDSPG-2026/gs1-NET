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
            .HasColumnName("ID_DADO_ORBITAL");

        b.Property(d => d.IdFazenda)
            .HasColumnName("ID_FAZENDA");

        b.Property(d => d.Fonte)
            .HasColumnName("FONTE")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(d => d.DtColeta)
            .HasColumnName("DT_COLETA")
            .IsRequired();

        b.Property(d => d.IrradianciaPar)
            .HasColumnName("IRRADIANCIA_PAR")
            .HasPrecision(8, 3);

        b.Property(d => d.Nebulosidade)
            .HasColumnName("NEBULOSIDADE")
            .HasPrecision(5, 2);

        b.Property(d => d.TemperaturaAmbiente)
            .HasColumnName("TEMPERATURA_AMBIENTE")
            .HasPrecision(6, 2);

        b.Property(d => d.Latitude)
            .HasColumnName("LATITUDE")
            .HasPrecision(10, 7);

        b.Property(d => d.Longitude)
            .HasColumnName("LONGITUDE")
            .HasPrecision(11, 7);

        b.HasOne(d => d.Fazenda)
            .WithMany(f => f.DadosOrbitais)
            .HasForeignKey(d => d.IdFazenda);
    }
}