using DarkDhamon.Common.EntityFramework.DataRepository;

namespace DarkDhamon.Common.EntityFramework.Model
{

    public interface ITrackedEntity<TKey, TUser>
        : IEntity<TKey>
        where TKey : struct
        where TUser : class
    {
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
        DateTime? Deleted { get; set; }
        TUser CreatedBy { get; set; }
        TUser LastUpdatedBy { get; set; }
        TUser DeletedBy { get; set; }
    }
}