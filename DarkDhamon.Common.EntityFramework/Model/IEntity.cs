using System.ComponentModel.DataAnnotations;

namespace DarkDhamon.Common.EntityFramework.Model;

public interface IEntity<TKey> 
    where TKey : struct
{
    [Key]
    TKey Id { get; set; }
}