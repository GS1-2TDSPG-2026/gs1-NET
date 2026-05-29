using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class PrevisaoIa : BaseEntity
{
    public Guid TanqueId { get; set; }

    public Guid DadoOrbitalId { get; set; }

    public DateTime DtPrevisao { get; set; }

    public decimal BiomassaGL { get; set; }

    public DateTime DtPicoPrevisto { get; set; }

    public decimal ConfiancaPct { get; set; }

    public string ModeloUtilizado { get; set; } = string.Empty;

    public virtual Tanque Tanque { get; set; } = null!;

    public virtual DadoOrbital DadoOrbital { get; set; } = null!;
}