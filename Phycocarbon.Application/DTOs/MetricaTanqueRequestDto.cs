using System.ComponentModel.DataAnnotations;
using System;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record MetricaTanqueRequestDto(
    [Required(ErrorMessage = "O Id do dispositivo é obrigatório")] Guid IdDispositivo,

    [Required(ErrorMessage = "O Id do tanque é obrigatório")] Guid IdTanque,

    decimal? Ph = null,
    decimal? Temperatura = null,
    decimal? Turbidez = null,
    decimal? Luminosidade = null,

    [StringLength(2000, ErrorMessage = "Payload original deve ter no máximo 2000 caracteres")]
    string? PayloadOriginal = null
){
    public MetricaTanque ToDomain() =>
        new(
            IdDispositivo,
            IdTanque,
            Ph,
            Temperatura,
            Turbidez,
            Luminosidade,
            PayloadOriginal);
}