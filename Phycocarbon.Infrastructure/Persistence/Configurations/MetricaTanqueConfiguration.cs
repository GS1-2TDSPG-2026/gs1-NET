using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class MetricaTanqueConfiguration : IEntityTypeConfiguration<MetricaTanque>
{
    public void Configure(EntityTypeBuilder<MetricaTanque> b)
    {
        b.ToTable("TB_METRICAS_TANQUE");

        b.HasKey(m => m.IdMetrica);

        b.Property(m => m.IdMetrica)
            .HasColumnName("ID_METRICA");

        b.Property(m => m.IdDispositivo)
            .HasColumnName("ID_DISPOSITIVO");

        b.Property(m => m.IdTanque)
            .HasColumnName("ID_TANQUE");

        b.Property(m => m.DtLeitura)
            .HasColumnName("DT_LEITURA")
            .IsRequired();

        b.Property(m => m.Ph)
            .HasColumnName("PH")
            .HasPrecision(5, 2);

        b.Property(m => m.Temperatura)
            .HasColumnName("TEMPERATURA")
            .HasPrecision(6, 2);

        b.Property(m => m.Turbidez)
            .HasColumnName("TURBIDEZ")
            .HasPrecision(8, 3);

        b.Property(m => m.Luminosidade)
            .HasColumnName("LUMINOSIDADE")
            .HasPrecision(10, 2);

        b.Property(m => m.PayloadOriginal)
            .HasColumnName("PAYLOAD_ORIGINAL")
            .HasMaxLength(4000);

        b.HasOne(m => m.Dispositivo)
            .WithMany(d => d.Metricas)
            .HasForeignKey(m => m.IdDispositivo);

        b.HasOne(m => m.Tanque)
            .WithMany(t => t.Metricas)
            .HasForeignKey(m => m.IdTanque);
    }
}