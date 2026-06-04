using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IMetricaTanqueService
{
    IReadOnlyList<MetricaTanqueResponseDto> GetAll();

    MetricaTanqueResponseDto? GetById(long id);

    MetricaTanqueResponseDto Create(MetricaTanqueRequestDto request);

    bool Delete(long id);
}
