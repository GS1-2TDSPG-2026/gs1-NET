using Phycocarbon.Domain.Entities;
using System;

namespace Phycocarbon.Application.DTOs;

public record PrevisaoIaResponseDto(
    long IdPrevisao,
    long IdTanque,
    long IdDadoOrbital,
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
