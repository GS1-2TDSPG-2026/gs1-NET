using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class FazendaService(
    IFazendaRepository repository)
    : IFazendaService
{
    public IEnumerable<FazendaResponseDto> GetAll()
    {
        return repository
            .GetAll()
            .Select(FazendaResponseDto.FromDomain);
    }

    public FazendaResponseDto GetById(long id)
    {
        var fazenda = repository.GetById(id);

        if (fazenda is null)
            throw new KeyNotFoundException(
                "Fazenda não encontrada.");

        return FazendaResponseDto.FromDomain(fazenda);
    }
}