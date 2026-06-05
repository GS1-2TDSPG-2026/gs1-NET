using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface ITanqueRepository
{
    IEnumerable<Tanque> GetAll();

    Tanque? GetById(long id);
}