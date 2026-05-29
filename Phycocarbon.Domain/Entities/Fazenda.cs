using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class Fazenda : BaseEntity
{
    public Guid UsuarioResponsavelId { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string Uf { get; set; } = string.Empty;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime DtCadastro { get; set; }

    // Navigation

    public virtual Usuario UsuarioResponsavel { get; set; } = null!;

    public virtual ICollection<Tanque> Tanques { get; set; }
        = new List<Tanque>();

    public virtual ICollection<DadoOrbital> DadosOrbitais { get; set; }
        = new List<DadoOrbital>();
}