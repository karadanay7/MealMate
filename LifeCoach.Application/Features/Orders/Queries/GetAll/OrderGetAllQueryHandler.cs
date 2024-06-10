using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeCoach.Application;

public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
{

    private readonly ICurrentUserService _currentUserService;
    private readonly IApplicationDbContext _applicationDbContext;
    public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
    {
        _currentUserService = currentUserService;
        _applicationDbContext = applicationDbContext;
    }
  public Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
  {
    return _applicationDbContext.MealPlanOrders.Where(x => x.UserId == _currentUserService.UserId)
        .Select(x => OrderGetAllDto.FromOrder(x))
        .ToListAsync(cancellationToken);
  }
}
