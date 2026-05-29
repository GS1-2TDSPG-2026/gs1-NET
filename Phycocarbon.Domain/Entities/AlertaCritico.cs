using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class AlertaCritico : BaseEntity
{
    public Guid MetricaTanqueId { get; set; }

    public Guid TanqueId { get; set; }

    public string TipoAlerta { get; set; } = string.Empty;

    public string Severidade { get; set; } = string.Empty;

    public string Mensagem { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime DtAlerta { get; set; }

    public virtual MetricaTanque MetricaTanque { get; set; } = null!;

    public virtual Tanque Tanque { get; set; } = null!;
}