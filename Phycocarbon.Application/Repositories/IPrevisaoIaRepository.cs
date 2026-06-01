using System;
using System.Collections.Generic;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IPrevisaoIaRepository : IRepository<PrevisaoIa>
{
    IEnumerable<PrevisaoIa> GetByTanque(Guid idTanque);

    IEnumerable<PrevisaoIa> GetByDadoOrbital(Guid idDadoOrbital);

    IEnumerable<PrevisaoIa> GetByDateRange(Guid idTanque, DateTime dataInicio, DateTime dataFim);
}
