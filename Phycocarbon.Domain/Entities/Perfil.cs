using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class Perfil : BaseEntity
{
    public string NomePerfil { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public virtual ICollection<Usuario> Usuarios { get; set; }
        = new List<Usuario>();
}