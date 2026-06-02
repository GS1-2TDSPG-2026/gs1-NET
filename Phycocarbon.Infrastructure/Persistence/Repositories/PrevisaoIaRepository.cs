using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class PrevisaoIaRepository(
    PhycocarbonContext context)
    : Repository<PrevisaoIa>(context),
        IPrevisaoIaRepository
{
}