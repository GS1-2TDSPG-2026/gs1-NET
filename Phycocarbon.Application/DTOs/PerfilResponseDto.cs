using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record PerfilResponseDto(
    long IdPerfil,
    string NomePerfil,
    string? Descricao)
{
    public static PerfilResponseDto FromDomain(
        Perfil perfil)
    {
        return new PerfilResponseDto(
            perfil.IdPerfil,
            perfil.NomePerfil,
            perfil.Descricao);
    }
}