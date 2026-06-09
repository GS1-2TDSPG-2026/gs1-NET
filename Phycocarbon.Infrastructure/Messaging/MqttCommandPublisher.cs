using Microsoft.Extensions.Options;
using MQTTnet;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Infrastructure.Messaging;

public sealed class MqttCommandPublisher(
    IOptions<MqttOptions> options)
    : IMqttCommandPublisher
{
    private readonly MqttOptions _options = options.Value;

    public async Task PublicarComandoAsync(
        string topic,
        string payload)
    {
        var factory = new MqttClientFactory();

        var client = factory.CreateMqttClient();

        var clientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer(
                _options.Host,
                _options.Port)
            .WithClientId(
                $"{_options.ClientId}-publisher-{Guid.NewGuid()}")
            .WithCleanSession()
            .Build();

        await client.ConnectAsync(clientOptions);

        var message =
            new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

        await client.PublishAsync(message);

        var disconnectOptions =
            new MqttClientDisconnectOptions();

        await client.DisconnectAsync(
            disconnectOptions,
            CancellationToken.None);
    }
}