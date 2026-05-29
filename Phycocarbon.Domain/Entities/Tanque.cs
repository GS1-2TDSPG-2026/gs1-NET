using Phycocarbon.Domain.Common;

namespace Phycocarbon.Domain.Entities;

public class Tanque : BaseEntity
{
    public Guid FazendaId { get; set; }

    public string CodigoTanque { get; set; } = string.Empty;

    public string TipoAlga { get; set; } = string.Empty;

    public decimal CapacidadeLitros { get; set; }

    public decimal PhMin { get; set; }

    public decimal PhMax { get; set; }

    public decimal TemperaturaMin { get; set; }

    public decimal TemperaturaMax { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime DtInstalacao { get; set; }

    // Navigation

    public virtual Fazenda Fazenda { get; set; } = null!;

    public virtual ICollection<DispositivoIot> Dispositivos { get; set; }
        = new List<DispositivoIot>();

    public virtual ICollection<MetricaTanque> Metricas { get; set; }
        = new List<MetricaTanque>();

    public virtual ICollection<AlertaCritico> Alertas { get; set; }
        = new List<AlertaCritico>();

    public virtual ICollection<PrevisaoIa> Previsoes { get; set; }
        = new List<PrevisaoIa>();
}