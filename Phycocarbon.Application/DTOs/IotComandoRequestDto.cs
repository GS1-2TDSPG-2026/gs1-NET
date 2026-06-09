using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Phycocarbon.Application.DTOs;

public class IotComandoRequestDto
{
    [Required]
    [JsonPropertyName("idDispositivo")]
    public long IdDispositivo { get; set; }

    [Required]
    [JsonPropertyName("comando")]
    public string Comando { get; set; } = string.Empty;
}