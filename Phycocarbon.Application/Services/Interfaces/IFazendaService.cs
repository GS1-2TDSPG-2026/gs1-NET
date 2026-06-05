using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IFazendaService
{
    IEnumerable<FazendaResponseDto> GetAll();

    FazendaResponseDto GetById(long id);
}