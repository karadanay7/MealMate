using MediatR;

namespace LifeCoach.Application;

public class OrderGetByIdQuery : IRequest<OrderGetByIdDto>

{

    public Guid Id { get; set; }
    public OrderGetByIdQuery(Guid id)
    {
        Id = id;
    }
}
