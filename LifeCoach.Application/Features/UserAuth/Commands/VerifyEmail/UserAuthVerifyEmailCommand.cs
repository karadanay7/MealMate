using LifeCoach.Application;
using MediatR;


public class UserAuthVerifyEmailCommand:IRequest<ResponseDto<string>>
{
 public string Email { get; set; }
    public string Token { get; set; }
    public UserAuthVerifyEmailCommand(string email, string token)
    {
        Email = email;
        Token = token;
    }
    public UserAuthVerifyEmailCommand()
    {
        
    }
}
