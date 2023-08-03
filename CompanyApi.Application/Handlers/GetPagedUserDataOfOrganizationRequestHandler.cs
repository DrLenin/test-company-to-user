namespace CompanyApi.Application.Handlers
{
    public class GetPagedUserDataOfOrganizationRequestHandler
        : IRequestHandler<GetPagedUserOfOrganizationCommand, Result<User[]>>
    {
        private readonly IUserRepository _userRepository;

        public GetPagedUserDataOfOrganizationRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<Result<User[]>> Handle(GetPagedUserOfOrganizationCommand request, CancellationToken cancellationToken)
        {
            //TODO: added not found

            return await _userRepository.GetUsersByCompanyIdTakeAndSkipAsync(request.OrganizationId, request.PageNumber,
                request.PageSize);
        }
    }
}
