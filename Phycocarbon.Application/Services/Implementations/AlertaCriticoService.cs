using Phycocarbon.Application.DTOs;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Application.Services.Interfaces;
using Phycocarbon.Domain.Entities;

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
    public void GerarAlertas(MetricaTanque metrica)
{
    if (metrica.Ph is not null)
    {
        if (metrica.Ph < 6)
        {
            CriarAlerta(
                metrica,
                "PH_BAIXO",
                "CRITICA",
                $"pH abaixo do limite crítico: {metrica.Ph}");
        }
        else if (metrica.Ph > 11)
        {
            CriarAlerta(
                metrica,
                "PH_ALTO",
                "CRITICA",
                $"pH acima do limite crítico: {metrica.Ph}");
        }
        else if (metrica.Ph < 7 || metrica.Ph > 10)
        {
            CriarAlerta(
                metrica,
                "PH_CRITICO",
                "ALTA",
                $"pH fora da faixa ideal: {metrica.Ph}");
        }
    }

    if (metrica.Temperatura is not null)
    {
        if (metrica.Temperatura > 40)
        {
            CriarAlerta(
                metrica,
                "TEMPERATURA_ALTA",
                "CRITICA",
                $"Temperatura crítica: {metrica.Temperatura}°C");
        }
        else if (metrica.Temperatura > 35)
        {
            CriarAlerta(
                metrica,
                "TEMPERATURA_ALTA",
                "ALTA",
                $"Temperatura elevada: {metrica.Temperatura}°C");
        }
        else if (metrica.Temperatura < 15)
        {
            CriarAlerta(
                metrica,
                "TEMPERATURA_BAIXA",
                "ALTA",
                $"Temperatura abaixo do ideal: {metrica.Temperatura}°C");
        }
    }

    if (metrica.Turbidez is not null)
    {
        if (metrica.Turbidez > 1000)
        {
            CriarAlerta(
                metrica,
                "TURBIDEZ_FORA_PADRAO",
                "CRITICA",
                $"Turbidez crítica: {metrica.Turbidez}");
        }
        else if (metrica.Turbidez > 800)
        {
            CriarAlerta(
                metrica,
                "TURBIDEZ_FORA_PADRAO",
                "MEDIA",
                $"Turbidez acima do padrão: {metrica.Turbidez}");
        }
    }

    if (metrica.Luminosidade is not null &&
        metrica.Luminosidade < 100)
    {
        CriarAlerta(
            metrica,
            "LUMINOSIDADE_BAIXA",
            "MEDIA",
            $"Luminosidade abaixo do recomendado: {metrica.Luminosidade}");
    }
}
    private void CriarAlerta(
        MetricaTanque metrica,
        string tipo,
        string severidade,
        string mensagem)
    {
        var alerta = new AlertaCritico(
            metrica.IdMetrica,
            metrica.IdTanque,
            tipo,
            severidade,
            mensagem,
            "ABERTO");

        alertaRepository.Add(alerta);
    }
    
    public bool Resolver(long id)
    {
        var alerta = alertaRepository.GetById(id);

        if (alerta is null)
            return false;

        alerta.Resolver();

        alertaRepository.Update(alerta);

        return true;
    }
}