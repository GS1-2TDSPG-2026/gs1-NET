using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IPerfilService
{
    IEnumerable<PerfilResponseDto> GetAll();

    PerfilResponseDto GetById(long id);
}