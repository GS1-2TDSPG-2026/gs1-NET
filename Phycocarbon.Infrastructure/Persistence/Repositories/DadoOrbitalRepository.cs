using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class DadoOrbitalRepository(
    PhycocarbonContext context)
    : Repository<DadoOrbital>(context),
        IDadoOrbitalRepository
{
}