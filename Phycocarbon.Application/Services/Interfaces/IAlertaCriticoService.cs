using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IAlertaCriticoService
{
    IReadOnlyList<AlertaCriticoResponseDto> GetAll();

    AlertaCriticoResponseDto? GetById(Guid id);

    AlertaCriticoResponseDto Create(AlertaCriticoRequestDto request);

    bool Delete(Guid id);
}
