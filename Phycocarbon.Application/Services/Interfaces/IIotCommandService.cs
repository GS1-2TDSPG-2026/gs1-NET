using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IIotCommandService
{
    Task EnviarComandoAsync(
        IotComandoRequestDto request);
}