using System.ComponentModel.DataAnnotations;

namespace DarkDhamon.Common.DataRepository
{
    public interface IEntity<TKey> where TKey : struct
    {
        [Key]
        TKey Id { get; set; }
    }
}