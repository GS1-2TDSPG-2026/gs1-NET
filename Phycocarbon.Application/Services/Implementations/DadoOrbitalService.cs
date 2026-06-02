using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class DadoOrbitalService(
    IDadoOrbitalRepository dadoOrbitalRepository)
    : IDadoOrbitalService
{
    public IReadOnlyList<DadoOrbitalResponseDto> GetAll()
    {
        return dadoOrbitalRepository
            .GetAll()
            .Select(DadoOrbitalResponseDto.FromDomain)
            .ToList();
    }

    public DadoOrbitalResponseDto? GetById(Guid id)
    {
        var dado = dadoOrbitalRepository.GetById(id);

        return dado is null
            ? null
            : DadoOrbitalResponseDto.FromDomain(dado);
    }

    public DadoOrbitalResponseDto Create(
        DadoOrbitalRequestDto request)
    {
        var dado = request.ToDomain();

        dadoOrbitalRepository.Add(dado);

        return DadoOrbitalResponseDto.FromDomain(dado);
    }

    public bool Delete(Guid id)
    {
        return dadoOrbitalRepository.Delete(id);
    }
}