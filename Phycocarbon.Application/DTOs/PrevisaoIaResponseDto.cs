using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record PrevisaoIaResponseDto(
    Guid IdPrevisao,
    Guid IdTanque,
    Guid IdDadoOrbital,
    DateTime DtPrevisao,
    decimal BiomassaGL,
    DateTime DtPicoPrevisto,
    decimal ConfiancaPct,
    string ModeloUtilizado
)
{
    public static PrevisaoIaResponseDto FromDomain(PrevisaoIa p) =>
        new(
            p.IdPrevisao,
            p.IdTanque,
            p.IdDadoOrbital,
            p.DtPrevisao,
            p.BiomassaGL,
            p.DtPicoPrevisto,
            p.ConfiancaPct,
            p.ModeloUtilizado
        );
}
