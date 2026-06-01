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
            .HasColumnName("id_previsao");

        b.Property(p => p.DtPrevisao)
            .HasColumnName("dt_previsao");

        b.Property(p => p.BiomassaGL)
            .HasColumnName("biomassa_gl")
            .HasPrecision(10, 2);

        b.Property(p => p.DtPicoPrevisto)
            .HasColumnName("dt_pico_previsto");

        b.Property(p => p.ConfiancaPct)
            .HasColumnName("confianca_pct")
            .HasPrecision(5, 2);

        b.Property(p => p.ModeloUtilizado)
            .HasColumnName("modelo_utilizado")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(p => p.IdTanque)
            .HasColumnName("id_tanque");

        b.Property(p => p.IdDadoOrbital)
            .HasColumnName("id_dado_orbital");

        b.HasOne(p => p.Tanque)
            .WithMany(t => t.Previsoes)
            .HasForeignKey(p => p.IdTanque);

        b.HasOne(p => p.DadoOrbital)
            .WithMany(d => d.Previsoes)
            .HasForeignKey(p => p.IdDadoOrbital);
    }
}
