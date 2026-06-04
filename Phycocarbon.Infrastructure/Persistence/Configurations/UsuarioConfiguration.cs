using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> b)
    {
        b.ToTable("TB_USUARIO");

        b.HasKey(u => u.IdUsuario);

        b.Property(u => u.IdUsuario)
            .HasColumnName("id_usuario");

        b.Property(u => u.Nome)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired();

        b.HasIndex(u => u.Email)
            .IsUnique();

        b.Property(u => u.SenhaHash)
            .HasColumnName("senha_hash")
            .HasMaxLength(255)
            .IsRequired();

        b.Property(u => u.Telefone)
            .HasColumnName("telefone")
            .HasMaxLength(30);

        b.Property(u => u.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        b.Property(u => u.DtCriacao)
            .HasColumnName("dt_criacao");

        b.Property(u => u.IdPerfil)
            .HasColumnName("id_perfil");

        b.HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.IdPerfil);
    }
}