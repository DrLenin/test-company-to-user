namespace TestApp.Infrastructure.Commands;

public class GetPagedUserOfOrganizationCommand : IRequest<Result<User[]>>
{
    public GetPagedUserOfOrganizationCommand(int pageSize, int pageNumber, Guid organizationId)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        OrganizationId = organizationId;
    }

    public Guid OrganizationId { get; private set; }

    public int PageNumber { get; private set; }

    public int PageSize { get; private set; }
}