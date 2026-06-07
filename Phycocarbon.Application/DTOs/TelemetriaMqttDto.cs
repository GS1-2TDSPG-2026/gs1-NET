namespace Phycocarbon.Application.DTOs;

using System.Text.Json.Serialization;

public sealed class TelemetriaMqttDto
{
    [JsonPropertyName("dispositivo_id")]
    public long DispositivoId { get; set; }

    [JsonPropertyName("pH")]
    public decimal PH { get; set; }

    [JsonPropertyName("temp")]
    public decimal Temperatura { get; set; }

    [JsonPropertyName("turbidez")]
    public int Turbidez { get; set; }

    [JsonPropertyName("luminosidade")]
    public int Luminosidade { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("pronto_colheita")]
    public bool ProntoColheita { get; set; }

    [JsonPropertyName("servo_aberto")]
    public bool ServoAberto { get; set; }
}