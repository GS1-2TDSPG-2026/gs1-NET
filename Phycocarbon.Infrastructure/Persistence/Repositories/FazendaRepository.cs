using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class FazendaRepository(
    PhycocarbonContext context)
    : IFazendaRepository
{
    public IEnumerable<Fazenda> GetAll()
    {
        return context.Fazendas
            .AsNoTracking()
            .ToList();
    }

    public Fazenda? GetById(long id)
    {
        return context.Fazendas
            .AsNoTracking()
            .FirstOrDefault(x => x.IdFazenda == id);
    }
}