using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record DadoOrbitalResponseDto(
    long IdDadoOrbital,
    long IdFazenda,
    string Fonte,
    DateTime DtColeta,
    decimal? IrradianciaPar,
    decimal? Nebulosidade,
    decimal? TemperaturaAmbiente,
    decimal? Latitude,
    decimal? Longitude
)
{
    public static DadoOrbitalResponseDto FromDomain(DadoOrbital d) =>
        new(
            d.IdDadoOrbital,
            d.IdFazenda,
            d.Fonte,
            d.DtColeta,
            d.IrradianciaPar,
            d.Nebulosidade,
            d.TemperaturaAmbiente,
            d.Latitude,
            d.Longitude
        );
}
