using System.Text.Json;
using MQTTnet;
using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.API.HostedServices;

public sealed class MqttTelemetryBackgroundService(
    IServiceScopeFactory scopeFactory,
    IConfiguration configuration,
    ILogger<MqttTelemetryBackgroundService> logger)
    : BackgroundService
{
    private IMqttClient? _mqttClient;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var host = configuration["Mqtt:Host"] ?? "broker.hivemq.com";
        var port = configuration.GetValue<int>("Mqtt:Port", 1883);
        var topic =
            configuration["Mqtt:Topic"] ??
            "phycocarbon/fiap/tanque01/telemetria";

        var clientId =
            configuration["Mqtt:ClientId"] ??
            $"phycocarbon-api-{Guid.NewGuid()}";

        var factory = new MqttClientFactory();

        _mqttClient = factory.CreateMqttClient();

        _mqttClient.ApplicationMessageReceivedAsync += async args =>
        {
            await HandleMessageAsync(args);
        };

        _mqttClient.ConnectedAsync += async _ =>
        {
            logger.LogInformation(
                "MQTT conectado ao broker {Host}:{Port}",
                host,
                port);

            var subscribeOptions = factory
                .CreateSubscribeOptionsBuilder()
                .WithTopicFilter(topic)
                .Build();

            await _mqttClient.SubscribeAsync(
                subscribeOptions,
                stoppingToken);

            logger.LogInformation(
                "Inscrito no tópico MQTT {Topic}",
                topic);
        };

        _mqttClient.DisconnectedAsync += async args =>
        {
            if (stoppingToken.IsCancellationRequested)
            {
                return;
            }

            logger.LogWarning(
                "MQTT desconectado. Tentando reconectar em 5 segundos. Motivo: {Reason}",
                args.Reason);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);

            try
            {
                await ConnectAsync(host, port, clientId, stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "Erro ao tentar reconectar ao MQTT.");
            }
        };

        await ConnectAsync(host, port, clientId, stoppingToken);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private async Task ConnectAsync(
        string host,
        int port,
        string clientId,
        CancellationToken cancellationToken)
    {
        if (_mqttClient is null)
        {
            return;
        }

        var options = new MqttClientOptionsBuilder()
            .WithClientId(clientId)
            .WithTcpServer(host, port)
            .WithCleanSession()
            .Build();

        await _mqttClient.ConnectAsync(options, cancellationToken);
    }

    private Task HandleMessageAsync(
        MqttApplicationMessageReceivedEventArgs args)
    {
        var topic = args.ApplicationMessage.Topic;

        var payload =
            args.ApplicationMessage.ConvertPayloadToString();

        logger.LogInformation(
            "Mensagem MQTT recebida no tópico {Topic}: {Payload}",
            topic,
            payload);

        try
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                logger.LogWarning("Payload MQTT vazio.");
                return Task.CompletedTask;
            }

            var request = JsonSerializer.Deserialize<IotTelemetriaRequestDto>(
                payload,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (request is null)
            {
                logger.LogWarning("Payload MQTT inválido.");
                return Task.CompletedTask;
            }

            using var scope = scopeFactory.CreateScope();

            var service = scope.ServiceProvider
                .GetRequiredService<IIotTelemetryService>();

            service.RegistrarTelemetria(request);

            logger.LogInformation(
                "Telemetria MQTT registrada com sucesso. Dispositivo: {DispositivoId}",
                request.DispositivoId);
        }
        catch (JsonException ex)
        {
            logger.LogError(
                ex,
                "Erro ao desserializar payload MQTT: {Payload}",
                payload);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Erro ao registrar telemetria recebida por MQTT.");
        }

        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_mqttClient?.IsConnected == true)
        {
            var disconnectOptions = new MqttClientDisconnectOptions();

            await _mqttClient.DisconnectAsync(
                disconnectOptions,
                cancellationToken);
        }

        await base.StopAsync(cancellationToken);
    }
}