namespace Phycocarbon.Domain.Entities;

public sealed class Tanque
{
    public Guid IdTanque { get; private set; }

    public Guid IdFazenda { get; private set; }

    public string CodigoTanque { get; private set; }

    public string TipoAlga { get; private set; }

    public decimal CapacidadeLitros { get; private set; }

    public decimal PhMin { get; private set; }

    public decimal PhMax { get; private set; }

    public decimal TemperaturaMin { get; private set; }

    public decimal TemperaturaMax { get; private set; }

    public string Status { get; private set; }

    public DateTime DtInstalacao { get; private set; }

    public Fazenda Fazenda { get; private set; } = null!;

    public DispositivoIot? DispositivoIot { get; private set; }

    public ICollection<MetricaTanque> Metricas { get; private set; } = [];

    public ICollection<AlertaCritico> Alertas { get; private set; } = [];

    public ICollection<PrevisaoIa> Previsoes { get; private set; } = [];

    private Tanque()
    {
    }

    public Tanque(
        Guid idFazenda,
        string codigoTanque,
        string tipoAlga,
        decimal capacidadeLitros,
        decimal phMin,
        decimal phMax,
        decimal temperaturaMin,
        decimal temperaturaMax,
        string status)
    {
        IdTanque = Guid.NewGuid();
        IdFazenda = idFazenda;
        CodigoTanque = codigoTanque;
        TipoAlga = tipoAlga;
        CapacidadeLitros = capacidadeLitros;
        PhMin = phMin;
        PhMax = phMax;
        TemperaturaMin = temperaturaMin;
        TemperaturaMax = temperaturaMax;
        Status = status;
        DtInstalacao = DateTime.UtcNow;
    }
}