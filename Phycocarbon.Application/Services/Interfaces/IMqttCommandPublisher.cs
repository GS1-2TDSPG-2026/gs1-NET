namespace Phycocarbon.Application.Services.Interfaces;

public interface IMqttCommandPublisher
{
    Task PublicarComandoAsync(
        string topic,
        string payload);
}