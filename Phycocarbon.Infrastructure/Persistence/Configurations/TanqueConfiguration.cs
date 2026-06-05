using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public sealed class TanqueConfiguration
    : IEntityTypeConfiguration<Tanque>
{
    public void Configure(
        EntityTypeBuilder<Tanque> b)
    {
        b.ToTable("TB_TANQUE");

        b.HasKey(t => t.IdTanque);

        b.Property(t => t.IdTanque)
            .HasColumnName("ID_TANQUE");

        b.Property(t => t.IdFazenda)
            .HasColumnName("ID_FAZENDA")
            .IsRequired();

        b.Property(t => t.CodigoTanque)
            .HasColumnName("CODIGO_TANQUE")
            .HasMaxLength(20)
            .IsRequired();

        b.Property(t => t.TipoAlga)
            .HasColumnName("TIPO_ALGA")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(t => t.CapacidadeLitros)
            .HasColumnName("CAPACIDADE_LITROS")
            .HasPrecision(10, 2)
            .IsRequired();

        b.Property(t => t.PhMin)
            .HasColumnName("PH_MIN")
            .HasPrecision(4, 2)
            .IsRequired();

        b.Property(t => t.PhMax)
            .HasColumnName("PH_MAX")
            .HasPrecision(4, 2)
            .IsRequired();

        b.Property(t => t.TemperaturaMin)
            .HasColumnName("TEMPERATURA_MIN")
            .HasPrecision(5, 2)
            .IsRequired();

        b.Property(t => t.TemperaturaMax)
            .HasColumnName("TEMPERATURA_MAX")
            .HasPrecision(5, 2)
            .IsRequired();

        b.Property(t => t.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(15)
            .IsRequired();

        b.Property(t => t.DtInstalacao)
            .HasColumnName("DT_INSTALACAO")
            .IsRequired();

        b.HasOne(t => t.Fazenda)
            .WithMany(f => f.Tanques)
            .HasForeignKey(t => t.IdFazenda)
            .HasConstraintName("FK_TANQUE_FAZENDA");
    }
}