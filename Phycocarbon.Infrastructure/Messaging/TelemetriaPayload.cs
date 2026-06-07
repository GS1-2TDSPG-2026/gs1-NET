namespace Phycocarbon.Infrastructure.Messaging;

public sealed class TelemetriaPayload
{
    public long DispositivoId { get; set; }

    public decimal? Ph { get; set; }

    public decimal? Temp { get; set; }

    public decimal? Turbidez { get; set; }

    public decimal? Luminosidade { get; set; }

    public string? Status { get; set; }

    public bool ProntoColheita { get; set; }

    public bool ServoAberto { get; set; }
}