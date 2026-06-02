using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class PrevisaoIaService(
    IPrevisaoIaRepository previsaoRepository)
    : IPrevisaoIaService
{
    public IReadOnlyList<PrevisaoIaResponseDto> GetAll()
    {
        return previsaoRepository
            .GetAll()
            .Select(PrevisaoIaResponseDto.FromDomain)
            .ToList();
    }

    public PrevisaoIaResponseDto? GetById(Guid id)
    {
        var previsao = previsaoRepository.GetById(id);

        return previsao is null
            ? null
            : PrevisaoIaResponseDto.FromDomain(previsao);
    }

    public PrevisaoIaResponseDto Create(
        PrevisaoIaRequestDto request)
    {
        var previsao = request.ToDomain();

        previsaoRepository.Add(previsao);

        return PrevisaoIaResponseDto.FromDomain(previsao);
    }

    public bool Delete(Guid id)
    {
        return previsaoRepository.Delete(id);
    }
}