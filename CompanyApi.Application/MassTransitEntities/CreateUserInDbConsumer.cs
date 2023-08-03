namespace CompanyApi.Application.MassTransitEntities;

public class CreateUserInDbConsumer 
    : IConsumer<CreateUserInDbTaskData> 
{
    private readonly IMapper _mapper;
    private readonly TestAppContext _dbContext;

    public CreateUserInDbConsumer(IMapper mapper, TestAppContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<CreateUserInDbTaskData> context)
    {
        var user = _mapper.Map<User>(context.Message);

        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}