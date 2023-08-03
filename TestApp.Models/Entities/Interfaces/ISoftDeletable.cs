namespace TestApp.Models.Entities.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}