namespace TestApp.Models.Entities;

public class Organization : BaseEntity
{
    public string Name { get; set; }

    public virtual List<User> Users { get; set; }
}