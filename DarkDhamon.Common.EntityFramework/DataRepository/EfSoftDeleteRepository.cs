using DarkDhamon.Common.EntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace DarkDhamon.Common.EntityFramework.DataRepository;

public abstract class EfSoftDeleteRepository<TContext, TEntity, TKey> 
    : EfBaseRepository<TContext, TEntity, TKey>, IRepository<TEntity, TKey>
    where TContext : DbContext
    where TEntity : class, IEntity<TKey>, ISoftDeletable
    where TKey : struct
{
    protected EfSoftDeleteRepository(TContext context) : base(context)
    {
    }
    public override IQueryable<TEntity> All()
    {
        return GetNonDeletedEntities();
    }
    public override void Delete(TEntity entity)
    {
        MarkEntityAsDeleted(entity);
        Update(entity);
    }
    private IQueryable<TEntity> GetNonDeletedEntities()
    {
        return Context.Set<TEntity>().Where(entity => !entity.IsDeleted);
    }
    private void MarkEntityAsDeleted(TEntity entity)
    {
        if (IsEntityDetached(entity))
        {
            AttachEntityToContext(entity);
        }
        entity.IsDeleted = true;
    }
    private bool IsEntityDetached(TEntity entity)
    {
        return Context.Entry(entity).State == EntityState.Detached;
    }
    private void AttachEntityToContext(TEntity entity)
    {
        Context.Set<TEntity>().Attach(entity);
    }
}
