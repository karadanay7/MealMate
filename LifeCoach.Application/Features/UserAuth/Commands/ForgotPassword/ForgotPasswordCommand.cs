using MediatR;


namespace LifeCoach.Application;

 public class ForgotPasswordCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
       
    }