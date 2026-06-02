using System;
using System.Collections.Generic;
using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IPrevisaoIaService
{
    IReadOnlyList<PrevisaoIaResponseDto> GetAll();

    PrevisaoIaResponseDto? GetById(Guid id);

    PrevisaoIaResponseDto Create(PrevisaoIaRequestDto request);

    bool Delete(Guid id);
}
