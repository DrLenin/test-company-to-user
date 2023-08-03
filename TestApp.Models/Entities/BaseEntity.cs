namespace TestApp.Models.Entities;

public class BaseEntity : ICreatable, ISoftDeletable, IUpdatable
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    
    public bool IsDeleted { get; set; }
}