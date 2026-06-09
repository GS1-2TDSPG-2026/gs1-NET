using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;
using Phycocarbon.Infrastructure.Messaging;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class IotCommandService(
    IDispositivoIotRepository dispositivoRepository,
    
    IMqttCommandPublisher mqttPublisher)
    : IIotCommandService
{
    public async Task EnviarComandoAsync(
        IotComandoRequestDto request)
    {
        var dispositivo =
            dispositivoRepository.GetById(
                request.IdDispositivo);

        if (dispositivo is null)
        {
            throw new InvalidOperationException(
                "Dispositivo não encontrado.");
        }

        await mqttPublisher.PublicarComandoAsync(
            dispositivo.TopicoMqtt,
            request.Comando);
    }
}