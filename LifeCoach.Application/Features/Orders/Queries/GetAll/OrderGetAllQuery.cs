using MediatR;

namespace LifeCoach.Application;

public class OrderGetAllQuery:IRequest<List<OrderGetAllDto>>
{

}
