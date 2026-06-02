using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IDadoOrbitalService
{
    IReadOnlyList<DadoOrbitalResponseDto> GetAll();

    DadoOrbitalResponseDto? GetById(Guid id);

    DadoOrbitalResponseDto Create(DadoOrbitalRequestDto request);

    bool Delete(Guid id);
}
