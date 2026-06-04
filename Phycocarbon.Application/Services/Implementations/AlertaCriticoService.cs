using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;

namespace Phycocarbon.Application.Services.Implementations;

public sealed class AlertaCriticoService(
    IAlertaCriticoRepository alertaRepository)
    : IAlertaCriticoService
{
    public IReadOnlyList<AlertaCriticoResponseDto> GetAll()
    {
        return alertaRepository
            .GetAll()
            .Select(AlertaCriticoResponseDto.FromDomain)
            .ToList();
    }

    public AlertaCriticoResponseDto? GetById(long id)
    {
        var alerta = alertaRepository.GetById(id);

        return alerta is null
            ? null
            : AlertaCriticoResponseDto.FromDomain(alerta);
    }

    public AlertaCriticoResponseDto Create(
        AlertaCriticoRequestDto request)
    {
        var alerta = request.ToDomain();

        alertaRepository.Add(alerta);

        return AlertaCriticoResponseDto.FromDomain(alerta);
    }
    

    public bool Delete(long id)
    {
        return alertaRepository.Delete(id);
    }
}