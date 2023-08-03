namespace TestApp.Infrastructure.Commands;

public class CompanyToUserCommand : IRequest<Result<string>>
{
    public Guid CompanyId { get; set; }
    
    public Guid UserId { get; set; }

    public CompanyToUserCommand(Guid companyId, Guid userId)
    {
        CompanyId = companyId;
        UserId = userId;
    }
}