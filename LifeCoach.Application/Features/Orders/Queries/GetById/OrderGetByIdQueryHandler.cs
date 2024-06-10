using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeCoach.Application;

public class OrderGetByIdQueryHandler:IRequestHandler <OrderGetByIdQuery, OrderGetByIdDto>
{
    private readonly IApplicationDbContext _dbContext;
 

    public OrderGetByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
 
    public async Task<OrderGetByIdDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _dbContext.MealPlanOrders.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return OrderGetByIdDto.MapFromOrder(order);
    }
}

