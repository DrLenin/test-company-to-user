namespace TestApp.Infrastructure.Commands;

public class CreateUserCommand : IRequest<Result<string>>
{
    public CreateUserCommand(string name, string surname, string patronymic, string phoneNumber, string email)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public string Name { get; private set; }

    public string Surname { get; private set; }

    public string Patronymic { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Surname)}: {Surname}, " +
               $"{nameof(Patronymic)}: {Patronymic}, " +
               $"{nameof(PhoneNumber)}: {PhoneNumber}, " +
               $"{nameof(Email)}: {Email}";
    }
}