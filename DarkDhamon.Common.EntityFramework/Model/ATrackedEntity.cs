namespace DarkDhamon.Common.EntityFramework.Model;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey">Type of primary key</typeparam>
/// <typeparam name="TUserKey">Type of foreign key</typeparam>
public abstract class ATrackedEntity<TKey,TUserKey>:AEntity<TKey>
    where TKey:struct
    where TUserKey:struct
{
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;
    public DateTime LastAccessed { get; set; } = DateTime.Now; 
    public TUserKey? CreatedByUserID { get; set; }
    public TUserKey? LastUpdatedByUserID { get; set; }
    public TUserKey? LastAccessedByUserID { get; set; }
}