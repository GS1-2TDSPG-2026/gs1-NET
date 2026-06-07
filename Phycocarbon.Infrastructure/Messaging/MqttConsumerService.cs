
using System.Buffers;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQTTnet;

namespace Phycocarbon.Infrastructure.Messaging;

public sealed class MqttConsumerService : BackgroundService
{
    private readonly ILogger<MqttConsumerService> _logger;
    private readonly MqttOptions _options;
    private readonly IMqttTelemetryProcessor _processor;
    
    public MqttConsumerService(
        ILogger<MqttConsumerService> logger,
        IOptions<MqttOptions> options,
        IMqttTelemetryProcessor processor)
    {
        _logger = logger;
        _options = options.Value;
        _processor = processor;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        try
        {
            var factory = new MqttClientFactory();
            var client = factory.CreateMqttClient();

            client.ApplicationMessageReceivedAsync += async e =>
            {
                var payloadBytes = new byte[
                    checked((int)e.ApplicationMessage.Payload.Length)];

                e.ApplicationMessage.Payload.CopyTo(payloadBytes);

                var payload = Encoding.UTF8.GetString(payloadBytes);

                try
                {
                    await _processor.ProcessAsync(
                        payload,
                        stoppingToken);
                }
                catch (Exception exception)
                {
                    _logger.LogError(
                        exception,
                        "Erro inesperado ao processar mensagem MQTT");
                }
            };

            _logger.LogInformation(
                "Conectando ao broker MQTT {Host}:{Port} com clientId {ClientId}",
                _options.Host,
                _options.Port,
                _options.ClientId);

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(
                    _options.Host,
                    _options.Port)
                .WithClientId(
                    _options.ClientId)
                .Build();

            await client.ConnectAsync(
                options,
                stoppingToken);

            await client.SubscribeAsync(
                _options.Topic,
                cancellationToken: stoppingToken);

            _logger.LogInformation(
                "Inscrito no tópico {Topic}",
                _options.Topic);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(
                    TimeSpan.FromSeconds(5),
                    stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Consumidor MQTT encerrado por cancelamento.");
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Falha fatal no consumidor MQTT");
        }
    }
}