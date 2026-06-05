using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class TanqueRepository(
    PhycocarbonContext context)
    : ITanqueRepository
{
    public IEnumerable<Tanque> GetAll()
    {
        return context.Tanques
            .AsNoTracking()
            .ToList();
    }

    public Tanque? GetById(long id)
    {
        return context.Tanques
            .AsNoTracking()
            .FirstOrDefault(x => x.IdTanque == id);
    }
}