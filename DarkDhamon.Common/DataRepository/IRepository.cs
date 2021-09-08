using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DarkDhamon.Common.DataRepository
{
    

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
}
