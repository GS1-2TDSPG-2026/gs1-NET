using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class PrevisaoIaConfiguration : IEntityTypeConfiguration<PrevisaoIa>
{
    public void Configure(EntityTypeBuilder<PrevisaoIa> b)
    {
        b.ToTable("TB_PREVISOES_IA");

        b.HasKey(p => p.IdPrevisao);

        b.Property(p => p.IdPrevisao)
            .HasColumnName("ID_PREVISAO");

        b.Property(p => p.IdTanque)
            .HasColumnName("ID_TANQUE");

        b.Property(p => p.IdDadoOrbital)
            .HasColumnName("ID_DADO_ORBITAL");

        b.Property(p => p.DtPrevisao)
            .HasColumnName("DT_PREVISAO")
            .IsRequired();

        b.Property(p => p.BiomassaGL)
            .HasColumnName("BIOMASSA_G_L")
            .HasPrecision(8, 4)
            .IsRequired();

        b.Property(p => p.DtPicoPrevisto)
            .HasColumnName("DT_PICO_PREVISTO")
            .IsRequired();

        b.Property(p => p.ConfiancaPct)
            .HasColumnName("CONFIANCA_PCT")
            .HasPrecision(5, 2)
            .IsRequired();

        b.Property(p => p.ModeloUtilizado)
            .HasColumnName("MODELO_UTILIZADO")
            .HasMaxLength(100)
            .IsRequired();

        b.HasOne(p => p.Tanque)
            .WithMany(t => t.Previsoes)
            .HasForeignKey(p => p.IdTanque);

        b.HasOne(p => p.DadoOrbital)
            .WithMany(d => d.Previsoes)
            .HasForeignKey(p => p.IdDadoOrbital);
    }
}