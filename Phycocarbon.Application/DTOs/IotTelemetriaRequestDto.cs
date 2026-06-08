using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Phycocarbon.Application.DTOs;

public sealed record IotTelemetriaRequestDto
{
    [Required(ErrorMessage = "O ID do dispositivo é obrigatório")]
    [JsonPropertyName("dispositivo_id")]
    public long DispositivoId { get; init; }

    [JsonPropertyName("pH")]
    public decimal? Ph { get; init; }

    [JsonPropertyName("temp")]
    public decimal? Temperatura { get; init; }

    [JsonPropertyName("turbidez")]
    public decimal? Turbidez { get; init; }

    [JsonPropertyName("luminosidade")]
    public decimal? Luminosidade { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("pronto_colheita")]
    public bool? ProntoColheita { get; init; }

    [JsonPropertyName("servo_aberto")]
    public bool? ServoAberto { get; init; }
}