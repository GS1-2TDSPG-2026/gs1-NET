namespace Phycocarbon.Domain.Entities;

public sealed class AlertaCritico
{
    public long IdAlerta { get; private set; }

    public long IdMetrica { get; private set; }

    public long IdTanque { get; private set; }

    public string TipoAlerta { get; private set; }

    public string Severidade { get; private set; }

    public string Mensagem { get; private set; }

    public string Status { get; private set; }

    public DateTime DtAlerta { get; private set; }

    public MetricaTanque Metrica { get; private set; } = null!;

    public Tanque Tanque { get; private set; } = null!;

    private AlertaCritico()
    {
    }

    public AlertaCritico(
        long idMetrica,
        long idTanque,
        string tipoAlerta,
        string severidade,
        string mensagem,
        string status)
    {
        IdAlerta = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        
        IdMetrica = idMetrica;
        IdTanque = idTanque;
        TipoAlerta = tipoAlerta;
        Severidade = severidade;
        Mensagem = mensagem;
        Status = status;
        DtAlerta = DateTime.UtcNow;
    }
}