namespace TestApp.Models.ApiModels;

public class UserRequest
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}

public class UserValidator : AbstractValidator<UserRequest>
{
    public UserValidator()
    {
        RuleFor(userData => userData)
            .Must(userData => string.IsNullOrEmpty(userData.Name))
            .WithName($"Имя ({nameof(UserRequest.Name)})");

        RuleFor(userData => userData)
            .Must(userData => string.IsNullOrEmpty(userData.Surname))
            .WithName($"Фамилия ({nameof(UserRequest.Surname)})");

        var phoneNumberPattern = "^9[0-9]{9}$";
        RuleFor(userData => userData)
            .Must(userData => string.IsNullOrEmpty(userData.PhoneNumber) && Regex.IsMatch(userData.PhoneNumber, phoneNumberPattern))
            .WithName($"Моб. телефон ({nameof(UserRequest.PhoneNumber)}, шаблон: {phoneNumberPattern})");

        RuleFor(userData => userData)
            .Must(userData => string.IsNullOrEmpty(userData.Email))
            .WithName($"Фамилия ({nameof(UserRequest.Surname)})");
    }
}