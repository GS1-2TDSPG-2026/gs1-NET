using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IAlertaCriticoService
{
    IReadOnlyList<AlertaCriticoResponseDto> GetAll();

    AlertaCriticoResponseDto? GetById(long id);

    AlertaCriticoResponseDto Create(AlertaCriticoRequestDto request);

    bool Delete(long id);
}
