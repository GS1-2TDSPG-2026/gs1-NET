using System.ComponentModel.DataAnnotations;
using System;

namespace Phycocarbon.Application.DTOs;

public record DispositivoIotRequestDto(
    [Required(ErrorMessage = "O Id do tanque é obrigatório")] Guid IdTanque,

    [Required(ErrorMessage = "O código de série é obrigatório")]
    [StringLength(50, ErrorMessage = "Código de série deve ter no máximo 50 caracteres")]
    string CodigoSerie,

    [Required(ErrorMessage = "O tópico MQTT é obrigatório")]
    [StringLength(200, ErrorMessage = "Tópico MQTT deve ter no máximo 200 caracteres")]
    string TopicoMqtt,

    [StringLength(200)]
    string? Modelo = null
);
