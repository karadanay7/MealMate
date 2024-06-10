using LifeCoach.Application;
using MediatR;


    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public ResetPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            await _identityService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword, cancellationToken);
                await _emailService.SendPasswordChangedNotificationAsync(request.Email , cancellationToken);
            return new ResponseDto<string>(request.Email, "Password reset successfully");
        }
    }

