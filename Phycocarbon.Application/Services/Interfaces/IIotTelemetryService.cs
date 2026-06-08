using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IIotTelemetryService
{
    MetricaTanqueResponseDto RegistrarTelemetria(IotTelemetriaRequestDto request);
}