using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class DispositivoIotRepository(
    PhycocarbonContext context)
    : Repository<DispositivoIot>(context),
        IDispositivoIotRepository
{
}