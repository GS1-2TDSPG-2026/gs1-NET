using System.Text.Json;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class IotTelemetryService(
    IDispositivoIotRepository dispositivoRepository,
    IMetricaTanqueRepository metricaRepository)
    : IIotTelemetryService
{
    public MetricaTanqueResponseDto RegistrarTelemetria(
        IotTelemetriaRequestDto request)
    {
        var dispositivo = dispositivoRepository.GetById(request.DispositivoId);

        if (dispositivo is null)
            throw new InvalidOperationException(
                $"Dispositivo IoT {request.DispositivoId} não encontrado no banco.");

        if (dispositivo.Ativo != "S")
            throw new InvalidOperationException(
                $"Dispositivo IoT {request.DispositivoId} está inativo.");

        var payloadOriginal = JsonSerializer.Serialize(request);

        var metrica = new MetricaTanque(
            dispositivo.IdDispositivo,
            dispositivo.IdTanque,
            request.Ph,
            request.Temperatura,
            request.Turbidez,
            request.Luminosidade,
            payloadOriginal
        );

        metricaRepository.Add(metrica);

        return MetricaTanqueResponseDto.FromDomain(metrica);
    }
}