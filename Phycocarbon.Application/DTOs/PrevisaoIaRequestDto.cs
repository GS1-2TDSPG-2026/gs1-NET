using System.ComponentModel.DataAnnotations;
using System;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record PrevisaoIaRequestDto(
    [Required(ErrorMessage = "O Id do tanque é obrigatório")] long IdTanque,

    [Required(ErrorMessage = "O Id do dado orbital é obrigatório")] long IdDadoOrbital,

    [Required(ErrorMessage = "A biomassa é obrigatória")]
    [Range(0, double.MaxValue, ErrorMessage = "Biomassa deve ser um valor não negativo")]
    decimal BiomassaGL,

    [Required(ErrorMessage = "A data do pico previsto é obrigatória")] DateTime DtPicoPrevisto,

    [Required(ErrorMessage = "A confiança é obrigatória")]
    [Range(0, 100, ErrorMessage = "Confiança deve estar entre 0 e 100")]
    decimal ConfiancaPct,

    [Required(ErrorMessage = "O modelo utilizado é obrigatório")]
    [StringLength(200, ErrorMessage = "Modelo utilizado deve ter no máximo 200 caracteres")]
    string ModeloUtilizado
){public PrevisaoIa ToDomain() =>
    new(
        IdTanque,
        IdDadoOrbital,
        BiomassaGL,
        DtPicoPrevisto,
        ConfiancaPct,
        ModeloUtilizado);
}