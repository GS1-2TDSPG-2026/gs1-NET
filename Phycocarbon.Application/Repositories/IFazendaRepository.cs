using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IFazendaRepository
{
    IEnumerable<Fazenda> GetAll();

    Fazenda? GetById(long id);
}