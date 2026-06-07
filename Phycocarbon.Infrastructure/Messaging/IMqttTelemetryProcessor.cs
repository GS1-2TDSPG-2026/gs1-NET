namespace Phycocarbon.Infrastructure.Messaging;

public interface IMqttTelemetryProcessor
{
    Task ProcessAsync(
        string payload,
        CancellationToken cancellationToken = default);
}