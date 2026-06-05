using Phycocarbon.Application.DTOs;

namespace Phycocarbon.Application.Services.Interfaces;

public interface IUsuarioService
{
    IEnumerable<UsuarioResponseDto> GetAll();

    UsuarioResponseDto GetById(long id);
}