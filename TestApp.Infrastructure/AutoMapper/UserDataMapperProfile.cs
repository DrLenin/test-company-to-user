namespace TestApp.Infrastructure.AutoMapper;

public class UserDataMapperProfile : Profile
{
    public UserDataMapperProfile()
    {
        CreateMap<CreateUserCommand, CreateUserInDbTaskData>();
        CreateMap<CreateUserInDbTaskData, User>();
    }
}