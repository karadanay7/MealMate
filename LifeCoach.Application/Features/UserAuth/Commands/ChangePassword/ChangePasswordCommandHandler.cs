using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LifeCoach.Application.Handlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ResponseDto<bool>>
    {
        private readonly IIdentityService _identityService;
     private readonly ICurrentUserService _currentUserService;
        private readonly IEmailService _emailService;

        public ChangePasswordCommandHandler(IIdentityService identityService, ICurrentUserService currentUserService, IEmailService emailService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
            
        }

    public async Task<ResponseDto<bool>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
      await _identityService.ChangePasswordAsync(_currentUserService.UserId,  request.CurrentPassword,request.NewPassword, cancellationToken);
      
        return new ResponseDto<bool>(true, "Password changed successfully");
    }
  }
}
