namespace DarkDhamon.Common.EntityFramework.Model;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}