namespace TestApp.Models.Entities;

public class User : BaseEntity
{
    public Organization Organization { get; set; }
    
    public Guid OrganizationId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}