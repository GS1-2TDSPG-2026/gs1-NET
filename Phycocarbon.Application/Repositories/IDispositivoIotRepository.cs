using System.Collections.Generic;
using Phycocarbon.Domain.Entities;

namespace Phycocarbon.Application.Repositories;

public interface IDispositivoIotRepository : IRepository<DispositivoIot>
{
    DispositivoIot? GetByCodigoSerie(string codigoSerie);

    IEnumerable<DispositivoIot> GetByTopicoMqtt(string topicoMqtt);
}
