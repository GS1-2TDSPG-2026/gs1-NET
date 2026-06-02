using System.ComponentModel.DataAnnotations;
using System;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record DadoOrbitalRequestDto(
    [Required(ErrorMessage = "O Id da fazenda é obrigatório")] Guid IdFazenda,

    [Required(ErrorMessage = "A fonte é obrigatória")]
    [StringLength(200, ErrorMessage = "Fonte deve ter no máximo 200 caracteres")]
    string Fonte,

    [Required(ErrorMessage = "A data de coleta é obrigatória")] DateTime DtColeta,
    decimal? IrradianciaPar = null,
    decimal? Nebulosidade = null,
    decimal? TemperaturaAmbiente = null,
    decimal? Latitude = null,
    decimal? Longitude = null
){
    public DadoOrbital ToDomain() =>
        new(
            IdFazenda,
            Fonte,
            DtColeta,
            IrradianciaPar,
            Nebulosidade,
            TemperaturaAmbiente,
            Latitude,
            Longitude);
}
