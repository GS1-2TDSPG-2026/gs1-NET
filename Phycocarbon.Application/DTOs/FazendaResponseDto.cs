using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record FazendaResponseDto(
    long IdFazenda,
    long IdUsuarioResponsavel,
    string Nome,
    string Cidade,
    string Uf,
    decimal? Latitude,
    decimal? Longitude,
    string Status,
    DateTime DtCadastro)
{
    public static FazendaResponseDto FromDomain(
        Fazenda fazenda)
    {
        return new FazendaResponseDto(
            fazenda.IdFazenda,
            fazenda.IdUsuarioResponsavel,
            fazenda.Nome,
            fazenda.Cidade,
            fazenda.Uf,
            fazenda.Latitude,
            fazenda.Longitude,
            fazenda.Status,
            fazenda.DtCadastro);
    }
}