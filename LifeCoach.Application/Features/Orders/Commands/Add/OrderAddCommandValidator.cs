using System.Diagnostics;
using FluentValidation;
using LifeCoach.Domain;

namespace LifeCoach.Application;

public class OrderAddCommandValidator:AbstractValidator<OrderAddCommand>
{
    private readonly ICurrentUserService _currentUserService;
    public OrderAddCommandValidator(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        RuleFor(x => x.Height).NotEmpty().GreaterThan(30).WithMessage("Please enter a valid weight");
        RuleFor(x => x.Weight).GreaterThan(0).WithMessage("Please enter a valid weight");
        RuleFor(x => x.Age).GreaterThan(0).WithMessage("Please enter a valid age");
        RuleFor(x=> x.Gender).IsInEnum().WithMessage("Please select a valid gender");
        RuleFor(x=> x.MealPreference).IsInEnum().WithMessage("Please select a valid meal preference");
        RuleFor(x=> x.ActivityLevel).IsInEnum().WithMessage("Please select a valid activity level");
        RuleFor(x=> x.Goal).IsInEnum().WithMessage("Please select a valid goal");
        RuleFor(x=> x.Allergies).MaximumLength(100).WithMessage("Allergies should not exceed 100 characters");
        RuleFor(x=> x.Disorders).MaximumLength(100).WithMessage("Disorders should not exceed 100 characters");
        RuleFor(x=> x.ActivityLevel).Must(IsUserIdValid).WithMessage("You need to be logged in to place an order");
    }
    private bool IsUserIdValid(ActivityLevel activityLevel) => _currentUserService.UserId == Guid.Empty;
   
}

