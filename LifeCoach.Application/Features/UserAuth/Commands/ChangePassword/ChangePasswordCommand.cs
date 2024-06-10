using LifeCoach.Application;
using MediatR;


namespace LifeCoach.Application;

   public class ChangePasswordCommand : IRequest<ResponseDto<bool>>
    {
     
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        
    }