using LifeCoach.Application;
using MediatR;



public class UserAuthLoginCommand : IRequest<ResponseDto<JwtDto>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
