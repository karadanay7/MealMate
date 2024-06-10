using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeCoach.Application;

public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, ResponseDto<Guid>>
{
    private readonly IApplicationDbContext _dbContext;
    public OrderDeleteCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
  public async Task<ResponseDto<Guid>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
  {
    var order = await _dbContext.MealPlanOrders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
    _dbContext.MealPlanOrders.Remove(order);
    await _dbContext.SaveChangesAsync(cancellationToken);
    return new ResponseDto<Guid> (order.Id, "Order deleted successfully");
  }
}
