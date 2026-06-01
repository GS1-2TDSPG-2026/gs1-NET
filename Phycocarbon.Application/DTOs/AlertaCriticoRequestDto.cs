using System.ComponentModel.DataAnnotations;
using System;

namespace Phycocarbon.Application.DTOs;

public record AlertaCriticoRequestDto(
    [Required(ErrorMessage = "O Id da métrica é obrigatório")] Guid IdMetrica,

    [Required(ErrorMessage = "O Id do tanque é obrigatório")] Guid IdTanque,

    [Required(ErrorMessage = "O tipo do alerta é obrigatório")]
    [StringLength(100, ErrorMessage = "Tipo de alerta deve ter no máximo 100 caracteres")]
    string TipoAlerta,

    [Required(ErrorMessage = "A severidade é obrigatória")]
    [StringLength(50, ErrorMessage = "Severidade deve ter no máximo 50 caracteres")]
    string Severidade,

    [Required(ErrorMessage = "A mensagem é obrigatória")]
    [StringLength(1000, ErrorMessage = "Mensagem deve ter no máximo 1000 caracteres")]
    string Mensagem,

    [Required(ErrorMessage = "O status é obrigatório")]
    [StringLength(50, ErrorMessage = "Status deve ter no máximo 50 caracteres")]
    string Status
);
