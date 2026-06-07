namespace Phycocarbon.Infrastructure.Messaging;

public sealed class MqttOptions
{
    public string Host { get; set; } = "broker.hivemq.com";

    public int Port { get; set; } = 1883;

    public string Topic { get; set; }
        = "phycocarbon/fiap/tanque01/telemetria";

    public string ClientId { get; set; }
        = "phycocarbon-api";
}