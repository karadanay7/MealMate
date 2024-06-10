namespace LifeCoach.Application;

public interface IEmailService
{
      Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken );
   Task SendPasswordResetAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken); 
   Task SendPasswordChangedNotificationAsync(string email, CancellationToken cancellationToken);
}
