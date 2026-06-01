namespace Phycocarbon.Domain.Entities;

public sealed class DispositivoIot
{
    public Guid IdDispositivo { get; private set; }

    public Guid IdTanque { get; private set; }

    public string CodigoSerie { get; private set; }

    public string TopicoMqtt { get; private set; }

    public string? Modelo { get; private set; }

    public bool Ativo { get; private set; }

    public DateTime DtInstalacao { get; private set; }

    public Tanque Tanque { get; private set; } = null!;

    public ICollection<MetricaTanque> Metricas { get; private set; } = [];

    private DispositivoIot()
    {
    }

    public DispositivoIot(
        Guid idTanque,
        string codigoSerie,
        string topicoMqtt,
        string? modelo)
    {
        IdDispositivo = Guid.NewGuid();
        IdTanque = idTanque;
        CodigoSerie = codigoSerie;
        TopicoMqtt = topicoMqtt;
        Modelo = modelo;
        Ativo = true;
        DtInstalacao = DateTime.UtcNow;
    }
}