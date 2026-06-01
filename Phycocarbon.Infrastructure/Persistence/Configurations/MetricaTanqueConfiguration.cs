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
            .HasColumnName("id_metrica");

        b.Property(m => m.DtLeitura)
            .HasColumnName("dt_leitura");

        b.Property(m => m.Ph)
            .HasColumnName("ph")
            .HasPrecision(4, 2);

        b.Property(m => m.Temperatura)
            .HasColumnName("temperatura")
            .HasPrecision(4, 2);

        b.Property(m => m.Turbidez)
            .HasColumnName("turbidez")
            .HasPrecision(4, 2);

        b.Property(m => m.Luminosidade)
            .HasColumnName("luminosidade")
            .HasPrecision(10, 2);

        b.Property(m => m.PayloadOriginal)
            .HasColumnName("payload_original")
            .HasMaxLength(255);

        b.Property(m => m.IdDispositivo)
            .HasColumnName("id_dispositivo");

        b.Property(m => m.IdTanque)
            .HasColumnName("id_tanque");

        b.HasOne(m => m.Dispositivo)
            .WithMany(d => d.Metricas)
            .HasForeignKey(m => m.IdDispositivo);

        b.HasOne(m => m.Tanque)
            .WithMany(t => t.Metricas)
            .HasForeignKey(m => m.IdTanque);
    }
}
