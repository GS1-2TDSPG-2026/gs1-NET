using System;
using System.Collections.Generic;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IMetricaTanqueRepository : IRepository<MetricaTanque>
{
    IEnumerable<MetricaTanque> GetByDispositivo(Guid idDispositivo);

    IEnumerable<MetricaTanque> GetByTanque(Guid idTanque);

    IEnumerable<MetricaTanque> GetByDateRange(Guid idTanque, DateTime dataInicio, DateTime dataFim);
}
