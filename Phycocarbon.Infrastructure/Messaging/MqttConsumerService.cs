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
        var factory = new MqttClientFactory();
        var client = factory.CreateMqttClient();

        try
        {
            client.ApplicationMessageReceivedAsync += async args =>
            {
                var payload =
                    args.ApplicationMessage.ConvertPayloadToString();

                _logger.LogInformation(
                    "Mensagem MQTT recebida no tópico {Topic}: {Payload}",
                    args.ApplicationMessage.Topic,
                    payload);

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
                        "Erro inesperado ao processar mensagem MQTT.");
                }
            };

            _logger.LogInformation(
                "Conectando ao broker MQTT {Host}:{Port} com clientId {ClientId}",
                _options.Host,
                _options.Port,
                _options.ClientId);

            var clientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(
                    _options.Host,
                    _options.Port)
                .WithClientId(
                    _options.ClientId)
                .WithCleanSession()
                .Build();

            await client.ConnectAsync(
                clientOptions,
                stoppingToken);

            var subscribeOptions = factory
                .CreateSubscribeOptionsBuilder()
                .WithTopicFilter(_options.Topic)
                .Build();

            await client.SubscribeAsync(
                subscribeOptions,
                stoppingToken);

            _logger.LogInformation(
                "Inscrito no tópico MQTT {Topic}",
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
            _logger.LogInformation(
                "Consumidor MQTT encerrado por cancelamento.");
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Falha fatal no consumidor MQTT.");
        }
        finally
        {
            if (client.IsConnected)
            {
                var disconnectOptions =
                    new MqttClientDisconnectOptions();

                await client.DisconnectAsync(
                    disconnectOptions,
                    CancellationToken.None);
            }
        }
    }
}