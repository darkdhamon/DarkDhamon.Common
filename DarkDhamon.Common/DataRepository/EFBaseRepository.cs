﻿using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DarkDhamon.Common.DataRepository
{
    public abstract class EfBaseRepository<TContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        protected TContext Context { get; }

        protected EfBaseRepository(TContext context)
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
    public abstract class EFBaseRepository<TContext, TEntity> : EfBaseRepository<TContext, TEntity, int>
        where TContext : DbContext
        where TEntity : class, IEntity<int>
    {
        protected EFBaseRepository(TContext context) : base(context)
        {
        }
    }
}