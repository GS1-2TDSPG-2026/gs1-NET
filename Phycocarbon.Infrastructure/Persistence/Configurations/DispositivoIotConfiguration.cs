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
            .HasColumnName("ID_DISPOSITIVO");

        b.Property(d => d.IdTanque)
            .HasColumnName("ID_TANQUE");

        b.Property(d => d.CodigoSerie)
            .HasColumnName("CODIGO_SERIE")
            .HasMaxLength(50)
            .IsRequired();

        b.Property(d => d.TopicoMqtt)
            .HasColumnName("TOPICO_MQTT")
            .HasMaxLength(200)
            .IsRequired();

        b.Property(d => d.Modelo)
            .HasColumnName("MODELO")
            .HasMaxLength(50);

        b.Property(d => d.Ativo)
            .HasColumnName("ATIVO")
            .HasMaxLength(1)
            .IsRequired();

        b.Property(d => d.DtInstalacao)
            .HasColumnName("DT_INSTALACAO")
            .IsRequired();

        b.HasOne(d => d.Tanque)
            .WithMany(t => t.Dispositivos)
            .HasForeignKey(d => d.IdTanque);
    }
}