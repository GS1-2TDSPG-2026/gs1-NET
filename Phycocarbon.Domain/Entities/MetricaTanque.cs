using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class MetricaTanque : BaseEntity
{
    public Guid DispositivoIotId { get; set; }

    public Guid TanqueId { get; set; }

    public DateTime DtLeitura { get; set; }

    public decimal Ph { get; set; }

    public decimal Temperatura { get; set; }

    public decimal Turbidez { get; set; }

    public decimal Luminosidade { get; set; }

    public string PayloadOriginal { get; set; } = string.Empty;

    public virtual DispositivoIot DispositivoIot { get; set; } = null!;

    public virtual Tanque Tanque { get; set; } = null!;

    public virtual ICollection<AlertaCritico> Alertas { get; set; }
        = new List<AlertaCritico>();
}