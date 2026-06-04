using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class TanqueConfiguration : IEntityTypeConfiguration<Tanque>
{
    public void Configure(EntityTypeBuilder<Tanque> b)
    {
        b.ToTable("TB_TANQUE");

        b.HasKey(t => t.IdTanque);

        b.Property(t => t.IdTanque)
            .HasColumnName("id_tanque");

        b.Property(t => t.CodigoTanque)
            .HasColumnName("codigo_tanque")
            .HasMaxLength(50)
            .IsRequired();

        b.Property(t => t.TipoAlga)
            .HasColumnName("tipo_alga")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(t => t.CapacidadeLitros)
            .HasColumnName("capacidade_litros")
            .HasPrecision(10, 2);

        b.Property(t => t.PhMin)
            .HasColumnName("ph_min")
            .HasPrecision(4, 2);

        b.Property(t => t.PhMax)
            .HasColumnName("ph_max")
            .HasPrecision(4, 2);

        b.Property(t => t.TemperaturaMin)
            .HasColumnName("temperatura_min")
            .HasPrecision(4, 2);

        b.Property(t => t.TemperaturaMax)
            .HasColumnName("temperatura_max")
            .HasPrecision(4, 2);

        b.Property(t => t.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(t => t.DtInstalacao)
            .HasColumnName("dt_instalacao");

        b.Property(t => t.IdFazenda)
            .HasColumnName("id_fazenda");

        b.HasOne(t => t.Fazenda)
            .WithMany(f => f.Tanques)
            .HasForeignKey(t => t.IdFazenda);
    }
}