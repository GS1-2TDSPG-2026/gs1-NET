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
            .HasColumnName("ID_FAZENDA");

        b.Property(f => f.IdUsuarioResponsavel)
            .HasColumnName("ID_USUARIO_RESPONSAVEL");

        b.Property(f => f.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(100)
            .IsRequired();

        b.Property(f => f.Cidade)
            .HasColumnName("CIDADE")
            .HasMaxLength(80)
            .IsRequired();

        b.Property(f => f.Uf)
            .HasColumnName("UF")
            .HasMaxLength(2)
            .IsRequired();

        b.Property(f => f.Latitude)
            .HasColumnName("LATITUDE")
            .HasPrecision(10, 7);

        b.Property(f => f.Longitude)
            .HasColumnName("LONGITUDE")
            .HasPrecision(11, 7);

        b.Property(f => f.Status)
            .HasColumnName("STATUS")
            .HasMaxLength(10)
            .IsRequired();

        b.Property(f => f.DtCadastro)
            .HasColumnName("DT_CADASTRO")
            .IsRequired();

        b.HasOne(f => f.UsuarioResponsavel)
            .WithMany(u => u.Fazendas)
            .HasForeignKey(f => f.IdUsuarioResponsavel);
    }
}