using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record AlertaCriticoResponseDto(
    long IdAlerta,
    long IdMetrica,
    long IdTanque,
    string TipoAlerta,
    string Severidade,
    string Mensagem,
    string Status,
    DateTime DtAlerta
)
{
    public static AlertaCriticoResponseDto FromDomain(AlertaCritico a) =>
        new(
            a.IdAlerta,
            a.IdMetrica,
            a.IdTanque,
            a.TipoAlerta,
            a.Severidade,
            a.Mensagem,
            a.Status,
            a.DtAlerta
        );
}
