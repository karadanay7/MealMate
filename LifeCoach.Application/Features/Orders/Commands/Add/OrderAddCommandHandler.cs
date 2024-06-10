using LifeCoach.Domain;
using MediatR;

namespace LifeCoach.Application;

  public class OrderAddCommandHandler: IRequestHandler<OrderAddCommand, ResponseDto<Guid>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IOpenAIService _openAIService;

        public OrderAddCommandHandler(IApplicationDbContext dbContext, ICurrentUserService currentUserService, IOpenAIService openAIService)
        {
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _openAIService = openAIService;
        }
       

        public async Task<ResponseDto<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
           var order = OrderAddCommand.MapToOrder(request);
           order.UserId = _currentUserService.UserId;
           order.CreatedByUserId    = _currentUserService.UserId.ToString();
           order.MealPlanResponses= await _openAIService.CreateMealPlanAsync(MealPlanRequestDto.MapFromOrderAddCommand(request),cancellationToken);

           order.CreatedByUserId = _currentUserService.UserId.ToString();

            /* TODO: Make Request to the Gemine or Dall-e 3 */

            _dbContext.MealPlanOrders.Add(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<Guid>(order.Id,"Your order completed successfully.");
        }
    }