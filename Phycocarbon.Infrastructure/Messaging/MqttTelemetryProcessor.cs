using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Infrastructure.Messaging;

public sealed class MqttTelemetryProcessor : IMqttTelemetryProcessor
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MqttTelemetryProcessor> _logger;

    public MqttTelemetryProcessor(
        IServiceScopeFactory scopeFactory,
        ILogger<MqttTelemetryProcessor> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public Task ProcessAsync(
        string payload,
        CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.CompletedTask;
        }

        if (string.IsNullOrWhiteSpace(payload))
        {
            _logger.LogWarning("Payload MQTT vazio ou nulo.");
            return Task.CompletedTask;
        }

        try
        {
            var telemetria = JsonSerializer.Deserialize<TelemetriaMqttDto>(
                payload,
                JsonOptions);

            if (telemetria is null)
            {
                _logger.LogWarning(
                    "Falha ao desserializar payload MQTT: objeto nulo.");

                return Task.CompletedTask;
            }

            if (telemetria.DispositivoId <= 0)
            {
                _logger.LogWarning(
                    "Payload MQTT inválido: DispositivoId deve ser maior que zero.");

                return Task.CompletedTask;
            }

            using var scope = _scopeFactory.CreateScope();

            var dispositivoRepository = scope.ServiceProvider.GetRequiredService<IDispositivoIotRepository>();
            var metricaService = scope.ServiceProvider.GetRequiredService<IMetricaTanqueService>();

            var dispositivo = dispositivoRepository.GetById(telemetria.DispositivoId);

            if (dispositivo is null)
            {
                _logger.LogWarning(
                    "Dispositivo IoT {DispositivoId} não encontrado.",
                    telemetria.DispositivoId);

                return Task.CompletedTask;
            }

            if (!string.Equals(dispositivo.Ativo, "S", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning(
                    "Dispositivo IoT {DispositivoId} está inativo.",
                    telemetria.DispositivoId);

                return Task.CompletedTask;
            }

            var request = new MetricaTanqueRequestDto(
                telemetria.DispositivoId,
                dispositivo.IdTanque,
                telemetria.PH,
                telemetria.Temperatura,
                telemetria.Turbidez,
                telemetria.Luminosidade,
                payload);

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);

            if (!Validator.TryValidateObject(
                    request,
                    validationContext,
                    validationResults,
                    validateAllProperties: true))
            {
                foreach (var validationResult in validationResults)
                {
                    _logger.LogWarning(
                        "Validação da métrica falhou: {Error}",
                        validationResult.ErrorMessage);
                }

                return Task.CompletedTask;
            }

            var response = metricaService.Create(request);

            _logger.LogInformation(
                "Métrica MQTT persistida com sucesso. IdMetrica: {IdMetrica}, IdDispositivo: {IdDispositivo}, IdTanque: {IdTanque}",
                response.IdMetrica,
                response.IdDispositivo,
                response.IdTanque);

            return Task.CompletedTask;
        }
        catch (JsonException exception)
        {
            _logger.LogError(
                exception,
                "Erro ao desserializar payload MQTT: {Payload}",
                payload);
            return Task.CompletedTask;
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Erro inesperado ao processar payload MQTT.");
            return Task.CompletedTask;
        }
    }
}