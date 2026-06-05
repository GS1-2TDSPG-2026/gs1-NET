using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public sealed class UsuarioConfiguration
    : IEntityTypeConfiguration<Usuario>
{
    public void Configure(
        EntityTypeBuilder<Usuario> b)
    {
        b.ToTable("TB_USUARIO");

        b.HasKey(u => u.IdUsuario);

        b.Property(u => u.IdUsuario)
            .HasColumnName("ID_USUARIO");

        b.Property(u => u.IdPerfil)
            .HasColumnName("ID_PERFIL")
            .IsRequired();

        b.Property(u => u.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(150)
            .IsRequired();

        b.HasIndex(u => u.Email)
            .IsUnique();

        b.Property(u => u.SenhaHash)
            .HasColumnName("SENHA_HASH")
            .HasMaxLength(255)
            .IsRequired();

        b.Property(u => u.Telefone)
            .HasColumnName("TELEFONE")
            .HasMaxLength(20);

        b.Property(u => u.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(1)
            .IsRequired();

        b.Property(u => u.DtCriacao)
            .HasColumnName("DT_CRIACAO")
            .IsRequired();

        b.HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.IdPerfil)
            .HasConstraintName("FK_USUARIO_PERFIL");
    }
}