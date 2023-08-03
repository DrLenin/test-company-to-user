namespace CompanyApi.Application.Handlers;

public class CompanyToUserHandler : IRequestHandler<CompanyToUserCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public CompanyToUserHandler(IUserRepository userRepository, IOrganizationRepository organizationRepository)
    {
        _userRepository = userRepository;
        _organizationRepository = organizationRepository;
    }
        
    public async Task<Result<string>> Handle(CompanyToUserCommand request, CancellationToken cancellationToken)
    {
        //TODO: added not found
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        var company = await _organizationRepository.GetCompanyByIdAsync(request.CompanyId);

        user.Organization = company;
        user.OrganizationId = company.Id;
        
        company.Users.Add(user);

        await _organizationRepository.SaveChangesAsync(cancellationToken);

        return "Added user in company";
    }
}