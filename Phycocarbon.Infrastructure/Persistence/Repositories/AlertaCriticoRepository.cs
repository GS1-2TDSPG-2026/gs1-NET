using Phycocarbon.Application.Repositories;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public sealed class AlertaCriticoRepository(
    PhycocarbonContext context)
    : Repository<AlertaCritico>(context),
        IAlertaCriticoRepository
{
}