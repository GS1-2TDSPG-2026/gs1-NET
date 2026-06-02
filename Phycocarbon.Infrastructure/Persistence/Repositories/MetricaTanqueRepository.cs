using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class MetricaTanqueRepository(
    PhycocarbonContext context)
    : Repository<MetricaTanque>(context),
        IMetricaTanqueRepository
{
}