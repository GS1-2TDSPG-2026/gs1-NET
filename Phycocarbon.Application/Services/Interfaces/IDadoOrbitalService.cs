using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IDadoOrbitalService
{
    IReadOnlyList<DadoOrbitalResponseDto> GetAll();

    DadoOrbitalResponseDto? GetById(long id);

    DadoOrbitalResponseDto Create(DadoOrbitalRequestDto request);

    bool Delete(long id);
}
