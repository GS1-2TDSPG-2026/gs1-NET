using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IMetricaTanqueService
{
    IReadOnlyList<MetricaTanqueResponseDto> GetAll();

    MetricaTanqueResponseDto? GetById(Guid id);

    MetricaTanqueResponseDto Create(MetricaTanqueRequestDto request);

    bool Delete(Guid id);
}
