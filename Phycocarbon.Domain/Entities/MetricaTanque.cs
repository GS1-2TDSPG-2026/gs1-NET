namespace Phycocarbon.Domain.Entities;

public sealed class MetricaTanque
{
    public long IdMetrica { get; private set; }

    public long IdDispositivo { get; private set; }

    public long IdTanque { get; private set; }

    public DateTime DtLeitura { get; private set; }

    public decimal? Ph { get; private set; }

    public decimal? Temperatura { get; private set; }

    public decimal? Turbidez { get; private set; }

    public decimal? Luminosidade { get; private set; }

    public string? PayloadOriginal { get; private set; }

    public DispositivoIot Dispositivo { get; private set; } = null!;

    public Tanque Tanque { get; private set; } = null!;

    public ICollection<AlertaCritico> Alertas { get; private set; } = [];

    private MetricaTanque()
    {
    }

    public MetricaTanque(
        long idDispositivo,
        long idTanque,
        decimal? ph,
        decimal? temperatura,
        decimal? turbidez,
        decimal? luminosidade,
        string? payloadOriginal)
    {
        IdMetrica = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        IdDispositivo = idDispositivo;
        IdTanque = idTanque;
        Ph = ph;
        Temperatura = temperatura;
        Turbidez = turbidez;
        Luminosidade = luminosidade;
        PayloadOriginal = payloadOriginal;
        DtLeitura = DateTime.UtcNow;
    }
}