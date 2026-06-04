namespace Phycocarbon.Domain.Entities;

public sealed class DispositivoIot
{
    public long IdDispositivo { get; private set; }

    public long IdTanque { get; private set; }

    public string CodigoSerie { get; private set; }

    public string TopicoMqtt { get; private set; }

    public string? Modelo { get; private set; }

    public string Ativo { get; private set; } = "S";

    public DateTime DtInstalacao { get; private set; }

    public Tanque Tanque { get; private set; } = null!;

    public ICollection<MetricaTanque> Metricas { get; private set; } = [];

    private DispositivoIot()
    {
    }

    public DispositivoIot(
        long idTanque,
        string codigoSerie,
        string topicoMqtt,
        string? modelo)
    {
        IdTanque = idTanque;
        CodigoSerie = codigoSerie;
        TopicoMqtt = topicoMqtt;
        Modelo = modelo;
        Ativo = "S";
        DtInstalacao = DateTime.UtcNow;
    }
}