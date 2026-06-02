using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class MetricaTanqueService(
    IMetricaTanqueRepository metricaRepository)
    : IMetricaTanqueService
{
    public IReadOnlyList<MetricaTanqueResponseDto> GetAll()
    {
        return metricaRepository
            .GetAll()
            .Select(MetricaTanqueResponseDto.FromDomain)
            .ToList();
    }

    public MetricaTanqueResponseDto? GetById(Guid id)
    {
        var metrica = metricaRepository.GetById(id);

        return metrica is null
            ? null
            : MetricaTanqueResponseDto.FromDomain(metrica);
    }

    public MetricaTanqueResponseDto Create(
        MetricaTanqueRequestDto request)
    {
        var metrica = request.ToDomain();

        metricaRepository.Add(metrica);

        return MetricaTanqueResponseDto.FromDomain(metrica);
    }

    public bool Delete(Guid id)
    {
        return metricaRepository.Delete(id);
    }
}