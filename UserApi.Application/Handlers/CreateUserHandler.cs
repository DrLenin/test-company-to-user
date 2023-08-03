namespace UserApi.Application.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<string>>
{
    private readonly IBus _bus;
    private readonly IMapper _mapper;

    public CreateUserHandler(IBus bus, IMapper mapper)
    {
        _bus = bus;
        _mapper = mapper;
    }

    public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Log.Information("Sending user to company service: {Request}", request);

        await _bus.Publish(_mapper.Map<CreateUserInDbTaskData>(request), cancellationToken);

        return $"User added";
    }
}