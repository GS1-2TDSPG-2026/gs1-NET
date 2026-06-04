using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IDispositivoIotService
{
    IReadOnlyList<DispositivoIotResponseDto> GetAll();

    DispositivoIotResponseDto? GetById(long id);

    DispositivoIotResponseDto Create(DispositivoIotRequestDto request);

    bool Delete(long id);
}
