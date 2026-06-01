using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> b)
    {
        b.ToTable("TB_PERFIL");

        b.HasKey(p => p.IdPerfil);

        b.Property(p => p.IdPerfil)
            .HasColumnName("id_perfil");

        b.Property(p => p.NomePerfil)
            .HasColumnName("nome_perfil")
            .HasMaxLength(100)
            .IsRequired();

        b.HasIndex(p => p.NomePerfil)
            .IsUnique();

        b.Property(p => p.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(255);
    }
}
