using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class DispositivoIotConfiguration : IEntityTypeConfiguration<DispositivoIot>
{
    public void Configure(EntityTypeBuilder<DispositivoIot> b)
    {
        b.ToTable("TB_DISPOSITIVO_IOT");

        b.HasKey(d => d.IdDispositivo);

        b.Property(d => d.IdDispositivo)
            .HasColumnName("id_dispositivo");

        b.Property(d => d.CodigoSerie)
            .HasColumnName("codigo_serie")
            .HasMaxLength(50)
            .IsRequired();

        b.Property(d => d.TopicoMqtt)
            .HasColumnName("topico_mqtt")
            .HasMaxLength(200)
            .IsRequired();

        b.Property(d => d.Modelo)
            .HasColumnName("modelo")
            .HasMaxLength(100);

        b.Property(d => d.Ativo)
            .HasColumnName("ativo");

        b.Property(d => d.DtInstalacao)
            .HasColumnName("dt_instalacao");

        b.Property(d => d.IdTanque)
            .HasColumnName("id_tanque");

        b.HasOne(d => d.Tanque)
            .WithMany(t => t.Dispositivos)
            .HasForeignKey(d => d.IdTanque);
    }
}
