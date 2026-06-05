using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> GetAll();

    Usuario? GetById(long id);
}