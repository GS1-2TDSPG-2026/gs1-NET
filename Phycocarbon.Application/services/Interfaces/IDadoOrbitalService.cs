using System;
using System.Collections.Generic;
using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IDadoOrbitalService
{
    IReadOnlyList<DadoOrbitalResponseDto> GetAll();

    DadoOrbitalResponseDto? GetById(Guid id);

    DadoOrbitalResponseDto Create(DadoOrbitalRequestDto request);

    DadoOrbitalResponseDto? Update(Guid id, DadoOrbitalRequestDto request);

    bool Delete(Guid id);
}
