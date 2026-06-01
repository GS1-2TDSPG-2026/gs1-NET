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
            .HasColumnName("id_alerta");

        b.Property(a => a.TipoAlerta)
            .HasColumnName("tipo_alerta")
            .HasMaxLength(50)
            .IsRequired();

        b.Property(a => a.Severidade)
            .HasColumnName("severidade")
            .HasMaxLength(50)
            .IsRequired();

        b.Property(a => a.Mensagem)
            .HasColumnName("mensagem")
            .HasMaxLength(500)
            .IsRequired();

        b.Property(a => a.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(a => a.DtAlerta)
            .HasColumnName("dt_alerta");

        b.Property(a => a.IdMetrica)
            .HasColumnName("id_metrica");

        b.Property(a => a.IdTanque)
            .HasColumnName("id_tanque");

        b.HasOne(a => a.Metrica)
            .WithMany(m => m.Alertas)
            .HasForeignKey(a => a.IdMetrica);

        b.HasOne(a => a.Tanque)
            .WithMany(t => t.Alertas)
            .HasForeignKey(a => a.IdTanque);
    }
}
