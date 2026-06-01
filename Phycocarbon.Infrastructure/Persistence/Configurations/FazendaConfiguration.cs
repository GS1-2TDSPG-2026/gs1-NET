using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class FazendaConfiguration : IEntityTypeConfiguration<Fazenda>
{
    public void Configure(EntityTypeBuilder<Fazenda> b)
    {
        b.ToTable("TB_FAZENDA");

        b.HasKey(f => f.IdFazenda);

        b.Property(f => f.IdFazenda)
            .HasColumnName("id_fazenda");

        b.Property(f => f.Nome)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(f => f.Cidade)
            .HasColumnName("cidade")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(f => f.Uf)
            .HasColumnName("uf")
            .HasMaxLength(2)
            .IsRequired();

        b.Property(f => f.Latitude)
            .HasColumnName("latitude")
            .HasPrecision(10, 7);

        b.Property(f => f.Longitude)
            .HasColumnName("longitude")
            .HasPrecision(10, 7);

        b.Property(f => f.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(f => f.DtCadastro)
            .HasColumnName("dt_cadastro");

        b.Property(f => f.IdUsuarioResponsavel)
            .HasColumnName("id_usuario_responsavel");

        b.HasOne(f => f.UsuarioResponsavel)
            .WithMany(u => u.Fazendas)
            .HasForeignKey(f => f.IdUsuarioResponsavel);
    }
}
