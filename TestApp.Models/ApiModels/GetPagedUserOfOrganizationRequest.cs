namespace TestApp.Models.ApiModels;

public class GetPagedUserOfOrganizationRequest
{
    public Guid OrganizationId { get; set; }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}