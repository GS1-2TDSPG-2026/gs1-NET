using Microsoft.Extensions.Options;
using MQTTnet;

namespace Phycocarbon.Infrastructure.Messaging;

public sealed class MqttCommandPublisher
    : IMqttCommandPublisher
{
    private readonly MqttOptions _options;

    public MqttCommandPublisher(
        IOptions<MqttOptions> options)
    {
        _options = options.Value;
    }

    public async Task PublicarComandoAsync(
        string topic,
        string payload)
    {
        var factory = new MqttClientFactory();

        var client = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(
                _options.Host,
                _options.Port)
            .WithClientId(
                $"{_options.ClientId}-publisher")
            .Build();

        await client.ConnectAsync(options);

        var message =
            new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

        await client.PublishAsync(message);

        await client.DisconnectAsync();
    }
}