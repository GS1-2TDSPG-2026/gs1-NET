using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.DTOs;

public record TanqueResponseDto(
    long IdTanque,
    long IdFazenda,
    string CodigoTanque,
    string TipoAlga,
    decimal CapacidadeLitros,
    decimal PhMin,
    decimal PhMax,
    decimal TemperaturaMin,
    decimal TemperaturaMax,
    string Status,
    DateTime DtInstalacao)
{
    public static TanqueResponseDto FromDomain(
        Tanque tanque)
    {
        return new TanqueResponseDto(
            tanque.IdTanque,
            tanque.IdFazenda,
            tanque.CodigoTanque,
            tanque.TipoAlga,
            tanque.CapacidadeLitros,
            tanque.PhMin,
            tanque.PhMax,
            tanque.TemperaturaMin,
            tanque.TemperaturaMax,
            tanque.Status,
            tanque.DtInstalacao);
    }
}