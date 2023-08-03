namespace TestApp.Models.ApiModels;

public class CompanyToUserRequest
{
    public Guid CompanyId { get; set; }
    
    public Guid UserId { get; set; }
}