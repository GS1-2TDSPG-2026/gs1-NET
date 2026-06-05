using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class PerfilRepository(
    PhycocarbonContext context)
    : IPerfilRepository
{
    public IEnumerable<Perfil> GetAll()
    {
        return context.Perfis
            .AsNoTracking()
            .ToList();
    }

    public Perfil? GetById(long id)
    {
        return context.Perfis
            .AsNoTracking()
            .FirstOrDefault(x => x.IdPerfil == id);
    }
}