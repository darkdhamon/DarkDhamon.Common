using System;

namespace DarkDhamon.Common.DataRepository
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface ITrackedEntity<TKey,TUser> : IEntity<TKey>
    {
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
        DateTime? Deleted { get; set; }

        TUser CreatedBy { get; set; }
        TUser LastUpdatedBy { get; set; }
        TUser DeletedBy { get; set; }
    }
}