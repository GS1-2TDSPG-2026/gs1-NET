namespace Phycocarbon.Infrastructure.Messaging;

public interface IMqttCommandPublisher
{
    Task PublicarComandoAsync(
        string topic,
        string payload);
}