using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class TanqueService(
    ITanqueRepository repository)
    : ITanqueService
{
    public IEnumerable<TanqueResponseDto> GetAll()
    {
        return repository
            .GetAll()
            .Select(TanqueResponseDto.FromDomain);
    }

    public TanqueResponseDto GetById(long id)
    {
        var tanque = repository.GetById(id);

        if (tanque is null)
            throw new KeyNotFoundException(
                "Tanque não encontrado.");

        return TanqueResponseDto.FromDomain(tanque);
    }
}