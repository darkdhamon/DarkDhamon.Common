using System.ComponentModel.DataAnnotations;

namespace DarkDhamon.Common.EntityFramework.Model;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TKey">Type of primary key</typeparam>
public abstract class AEntity<TKey>:IEntity<TKey> 
    where TKey : struct
{
    [Key]
    public TKey Id { get; set; }
}