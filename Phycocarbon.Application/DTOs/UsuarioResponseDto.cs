namespace Phycocarbon.Application.DTOs;

using Phycocarbon.Domain.Entities;

public sealed record UsuarioResponseDto(
    long IdUsuario,
    long IdPerfil,
    string Nome,
    string Email,
    string? Telefone,
    string Status,
    DateTime DtCriacao)
{
    public static UsuarioResponseDto FromDomain(
        Usuario usuario)
    {
        return new UsuarioResponseDto(
            usuario.IdUsuario,
            usuario.IdPerfil,
            usuario.Nome,
            usuario.Email,
            usuario.Telefone,
            usuario.Status,
            usuario.DtCriacao);
    }
}