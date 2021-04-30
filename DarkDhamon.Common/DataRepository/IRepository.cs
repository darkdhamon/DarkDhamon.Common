using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DarkDhamon.Common.DataRepository
{
    public abstract class EFBaseRepository<TContext, TEntity> : EFBaseRepository<TContext, TEntity, int>
        where TContext : DbContext
        where TEntity : class, IEntity<int>
    {
        protected EFBaseRepository(TContext context) : base(context)
        {
        }
    }

    public abstract class EFBaseRepository<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TContext: DbContext
    where TEntity: class, IEntity<TKey>
    where TKey: struct
    {
        protected TContext Context { get; }

        protected EFBaseRepository(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> All()
        {
            return Context.Set<TEntity>();
        }

        public TEntity Get(TKey entityId)
        {
            return Context.Find<TEntity>(entityId);
        }

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
    }

    public interface IRepository<TEntity,TKey> 
        where TEntity:class, IEntity<TKey>
        where TKey:struct
    {
        IQueryable<TEntity> All();
        TEntity Get(TKey entityId);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }

    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
