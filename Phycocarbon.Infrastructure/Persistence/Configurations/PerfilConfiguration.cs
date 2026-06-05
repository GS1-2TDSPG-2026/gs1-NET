using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public sealed class PerfilConfiguration
    : IEntityTypeConfiguration<Perfil>
{
    public void Configure(
        EntityTypeBuilder<Perfil> b)
    {
        b.ToTable("TB_PERFIL");

        b.HasKey(p => p.IdPerfil);

        b.Property(p => p.IdPerfil)
            .HasColumnName("ID_PERFIL");

        b.Property(p => p.NomePerfil)
            .HasColumnName("NOME_PERFIL")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(p => p.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(200);

        b.HasIndex(p => p.NomePerfil)
            .IsUnique();
    }
}