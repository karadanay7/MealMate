using MediatR;

namespace LifeCoach.Application;

public class OrderDeleteCommand :IRequest<ResponseDto<Guid>>
{
 public Guid Id { get; set; }
 public OrderDeleteCommand(Guid id)
 {
     Id = id;
 }
}
