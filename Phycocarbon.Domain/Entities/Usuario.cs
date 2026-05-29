using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class Usuario : BaseEntity
{
    public Guid PerfilId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string SenhaHash { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime DtCriacao { get; set; }

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual ICollection<Fazenda> Fazendas { get; set; }
        = new List<Fazenda>();
}