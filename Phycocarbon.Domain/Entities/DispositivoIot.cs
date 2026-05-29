using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class DispositivoIot : BaseEntity
{
    public Guid TanqueId { get; set; }

    public string CodigoSerie { get; set; } = string.Empty;

    public string TopicoMqtt { get; set; } = string.Empty;

    public string Modelo { get; set; } = string.Empty;

    public DateTime DtInstalacao { get; set; }

    public virtual Tanque Tanque { get; set; } = null; 
}
