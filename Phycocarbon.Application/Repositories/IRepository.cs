using System;
using System.Collections.Generic;

namespace Phycocarbon.Application.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll();

    TEntity? GetById(Guid id);

    void Add(TEntity entity);

    void Update(TEntity entity);

    bool Delete(Guid id);

    bool Exists(Guid id);
}
