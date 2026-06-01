using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record MetricaTanqueResponseDto(
    Guid IdMetrica,
    Guid IdDispositivo,
    Guid IdTanque,
    DateTime DtLeitura,
    decimal? Ph,
    decimal? Temperatura,
    decimal? Turbidez,
    decimal? Luminosidade,
    string? PayloadOriginal
)
{
    public static MetricaTanqueResponseDto FromDomain(MetricaTanque m) =>
        new(
            m.IdMetrica,
            m.IdDispositivo,
            m.IdTanque,
            m.DtLeitura,
            m.Ph,
            m.Temperatura,
            m.Turbidez,
            m.Luminosidade,
            m.PayloadOriginal
        );
}
