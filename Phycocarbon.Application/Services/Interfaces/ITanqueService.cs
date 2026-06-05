using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface ITanqueService
{
    IEnumerable<TanqueResponseDto> GetAll();

    TanqueResponseDto GetById(long id);
}