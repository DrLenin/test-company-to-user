namespace TestApp.CompanyApi.Apis;

public class CompanyApi : IApi
{
    public void RegisterActions(WebApplication application)
    {
        application.MapGet("/company/user", GetUsersByCompany);
        application.MapPost("/company/", CompanyToUser);
    }

    private async Task<ActionResult<User[]>> GetUsersByCompany([FromBody] GetPagedUserOfOrganizationRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new GetPagedUserOfOrganizationCommand(
            request.PageSize,
            request.PageNumber,
            request.OrganizationId));

        return result.Data;
    }
    
    private async Task<ActionResult<string>> CompanyToUser([FromBody] CompanyToUserRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new CompanyToUserCommand(request.CompanyId, request.UserId));

        return result.Data;
    }
}