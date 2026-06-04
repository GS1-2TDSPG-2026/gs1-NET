using Microsoft.EntityFrameworkCore;
using Phycocarbon.Application.Repositories;

namespace Phycocarbon.Infrastructure.Persistence.Repositories;

public class Repository<TEntity>(
    PhycocarbonContext context)
    : IRepository<TEntity>
    where TEntity : class
{
    protected PhycocarbonContext Context { get; } = context;

    private readonly DbSet<TEntity> _set =
        context.Set<TEntity>();

    public IEnumerable<TEntity> GetAll()
    {
        return _set
            .AsNoTracking()
            .ToList();
    }

    public TEntity? GetById(long id)
    {
        return _set.Find(id);
    }

    public void Add(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _set.Add(entity);

        Context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _set.Update(entity);

        Context.SaveChanges();
    }

    public bool Delete(long id)
    {
        var entity = GetById(id);

        if (entity is null)
            return false;

        _set.Remove(entity);

        Context.SaveChanges();

        return true;
    }

    public bool Exists(long id)
    {
        return _set.Find(id) is not null;
    }
}