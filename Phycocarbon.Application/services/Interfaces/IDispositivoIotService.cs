using System;
using System.Collections.Generic;
using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IDispositivoIotService
{
    IReadOnlyList<DispositivoIotResponseDto> GetAll();

    DispositivoIotResponseDto? GetById(Guid id);

    DispositivoIotResponseDto Create(DispositivoIotRequestDto request);

    DispositivoIotResponseDto? Update(Guid id, DispositivoIotRequestDto request);

    bool Delete(Guid id);
}
