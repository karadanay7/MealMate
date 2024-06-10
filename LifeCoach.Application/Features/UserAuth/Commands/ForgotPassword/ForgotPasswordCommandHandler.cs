using MediatR;


namespace LifeCoach.Application.Handlers
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public ForgotPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var token = await _identityService.GeneratePasswordResetTokenAsync(request.Email, cancellationToken);
            
            var emailDto = new EmailSendEmailVerificationDto
            {
                Email = request.Email,
                Token = token
            };
            
            await _emailService.SendPasswordResetAsync(emailDto, cancellationToken);

            return new ResponseDto<string>(request.Email, "Password reset email sent successfully");
        }
    }
}
