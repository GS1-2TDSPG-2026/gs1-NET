using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IPerfilRepository
{
    IEnumerable<Perfil> GetAll();

    Perfil? GetById(long id);
}