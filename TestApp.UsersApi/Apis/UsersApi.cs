namespace TestApp.UsersApi.Apis;

public class UsersApi : IApi
{
    public void RegisterActions(WebApplication application)
    {
        application.MapPost("/user", CreateUser);
    }

    private async Task<ActionResult<string>> CreateUser([FromBody] UserRequest request, IMediator mediator)
    {
        var result = await mediator.Send(new CreateUserCommand(
            request.Name,
            request.Surname,
            request.Patronymic,
            request.PhoneNumber, 
            request.Email));

        return result.Data;
    }
}