using System;
using System.Collections.Generic;
using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IPrevisaoIaService
{
    IReadOnlyList<PrevisaoIaResponseDto> GetAll();

    PrevisaoIaResponseDto? GetById(long id);

    PrevisaoIaResponseDto Create(PrevisaoIaRequestDto request);

    bool Delete(long id);
}
