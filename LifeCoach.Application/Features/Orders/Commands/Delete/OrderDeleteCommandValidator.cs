using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace LifeCoach.Application;

public class OrderDeleteCommandValidator : AbstractValidator<OrderDeleteCommand>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IApplicationDbContext _dbContext;
    public OrderDeleteCommandValidator (ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
    {
        _currentUserService = currentUserService;
        _dbContext = applicationDbContext;

        RuleFor(x => x.Id).MustAsync(IsOrderExistsAsync).WithMessage("Order not found");
        RuleFor(x => x.Id).MustAsync(IsOrderBelongsToCurrentUserAsync).WithMessage("Order does not belong to user");

           
    }
    private Task<bool> IsOrderExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.MealPlanOrders.AnyAsync(x => x.Id == id, cancellationToken);
    }
    private Task<bool> IsOrderBelongsToCurrentUserAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbContext.MealPlanOrders.Where(x => x.UserId == _currentUserService.UserId).AnyAsync(o => o.Id == id, cancellationToken);
    }

}
