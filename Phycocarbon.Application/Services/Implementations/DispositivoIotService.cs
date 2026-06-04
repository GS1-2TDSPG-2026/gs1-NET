using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class DispositivoIotService(
    IDispositivoIotRepository dispositivoRepository)
    : IDispositivoIotService
{
    public IReadOnlyList<DispositivoIotResponseDto> GetAll()
    {
        return dispositivoRepository
            .GetAll()
            .Select(DispositivoIotResponseDto.FromDomain)
            .ToList();
    }

    public DispositivoIotResponseDto? GetById(long id)
    {
        var dispositivo = dispositivoRepository.GetById(id);

        return dispositivo is null
            ? null
            : DispositivoIotResponseDto.FromDomain(dispositivo);
    }

    public DispositivoIotResponseDto Create(
        DispositivoIotRequestDto request)
    {
        var dispositivo = request.ToDomain();

        dispositivoRepository.Add(dispositivo);

        return DispositivoIotResponseDto.FromDomain(dispositivo);
    }

    public bool Delete(long id)
    {
        return dispositivoRepository.Delete(id);
    }
}