using LifeCoach.Application;
using MediatR;




  public class ResetPasswordCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }