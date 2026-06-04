using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class AlertaCriticoConfiguration : IEntityTypeConfiguration<AlertaCritico>
{
    public void Configure(EntityTypeBuilder<AlertaCritico> b)
    {
        b.ToTable("TB_ALERTA_CRITICO");

        b.HasKey(a => a.IdAlerta);

        b.Property(a => a.IdAlerta)
            .HasColumnName("ID_ALERTA");

        b.Property(a => a.TipoAlerta)
            .HasColumnName("TIPO_ALERTA");

        b.Property(a => a.Severidade)
            .HasColumnName("SEVERIDADE");

        b.Property(a => a.Mensagem)
            .HasColumnName("MENSAGEM");

        b.Property(a => a.Status)
            .HasColumnName("STATUS");

        b.Property(a => a.DtAlerta)
            .HasColumnName("DT_ALERTA");

        b.Property(a => a.IdMetrica)
            .HasColumnName("ID_METRICA");

        b.Property(a => a.IdTanque)
            .HasColumnName("ID_TANQUE");

        b.HasOne(a => a.Metrica)
            .WithMany(m => m.Alertas)
            .HasForeignKey(a => a.IdMetrica);

        b.HasOne(a => a.Tanque)
            .WithMany(t => t.Alertas)
            .HasForeignKey(a => a.IdTanque);
    }
}
