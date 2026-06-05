using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class PerfilService(
    IPerfilRepository repository)
    : IPerfilService
{
    public IEnumerable<PerfilResponseDto> GetAll()
    {
        return repository
            .GetAll()
            .Select(PerfilResponseDto.FromDomain);
    }

    public PerfilResponseDto GetById(long id)
    {
        var perfil = repository.GetById(id);

        if (perfil is null)
            throw new KeyNotFoundException(
                "Perfil não encontrado.");

        return PerfilResponseDto.FromDomain(perfil);
    }
}