using System;
using System.Collections.Generic;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IDadoOrbitalRepository : IRepository<DadoOrbital>
{
    IEnumerable<DadoOrbital> GetByFazenda(Guid idFazenda);

    IEnumerable<DadoOrbital> GetByDateRange(Guid idFazenda, DateTime dataInicio, DateTime dataFim);
}
