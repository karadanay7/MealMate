using System.Text.RegularExpressions;
using FluentValidation;

namespace LifeCoach.Application;

public class UserAuthValidatorBase<T>: AbstractValidator<T> where T : class
{
    protected readonly IIdentityService _identityService;
    public UserAuthValidatorBase(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    protected bool IsEmail(string email)
    {
           string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(emailPattern, email);
    }

}
