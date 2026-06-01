using System;
using System.Collections.Generic;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IAlertaCriticoRepository : IRepository<AlertaCritico>
{
    IEnumerable<AlertaCritico> GetByMetrica(Guid idMetrica);

    IEnumerable<AlertaCritico> GetByTanque(Guid idTanque);

    IEnumerable<AlertaCritico> GetByStatus(string status);

    IEnumerable<AlertaCritico> GetFiltered(Guid? idTanque, string? severidade, string? status);
}
