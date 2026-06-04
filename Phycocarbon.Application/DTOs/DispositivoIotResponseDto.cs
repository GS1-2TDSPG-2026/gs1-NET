
using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record DispositivoIotResponseDto(
    long IdDispositivo,
    long IdTanque,
    string CodigoSerie,
    string TopicoMqtt,
    string? Modelo,
    string Ativo,
    DateTime DtInstalacao
)
{
    public static DispositivoIotResponseDto FromDomain(DispositivoIot d) =>
        new(
            d.IdDispositivo,
            d.IdTanque,
            d.CodigoSerie,
            d.TopicoMqtt,
            d.Modelo,
            d.Ativo,
            d.DtInstalacao
        );
}
