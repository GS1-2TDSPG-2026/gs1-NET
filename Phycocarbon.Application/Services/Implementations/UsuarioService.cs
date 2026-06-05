using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class UsuarioService(
    IUsuarioRepository repository)
    : IUsuarioService
{
    public IEnumerable<UsuarioResponseDto> GetAll()
    {
        return repository
            .GetAll()
            .Select(UsuarioResponseDto.FromDomain);
    }

    public UsuarioResponseDto GetById(long id)
    {
        var usuario = repository.GetById(id);

        if (usuario is null)
            throw new KeyNotFoundException(
                "Usuário não encontrado.");

        return UsuarioResponseDto.FromDomain(usuario);
    }
}