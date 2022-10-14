namespace DarkDhamon.Common.EntityFramework.DataRepository
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

    public interface IRepository<TEntity>:IRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }
        
}
