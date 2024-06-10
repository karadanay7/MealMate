using System.Web;

using Resend;
using Microsoft.Extensions.Logging;
using LifeCoach.Application;


namespace LifeCoach.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;
        private readonly ILogger<ResendEmailManager> _logger;

        public ResendEmailManager(IResend resend, ILogger<ResendEmailManager> logger)
        {
            _resend = resend;
            _logger = logger;
        }

        private const string ApiBaseUrl = "https://localhost:5121/api/";

        public async Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            try
            {
                var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
                var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

                var link = $"{ApiBaseUrl}UsersAuths/verify-email?email={encodedEmail}&token={encodedToken}";
                var urlEncodedLink = HttpUtility.UrlEncode(link);

                var message = new EmailMessage
                {
                    From = "onboarding@resend.dev",
                    To = { emailDto.Email },
                    Subject = "Email Verification | IconBuilderAI",
                    HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>"
                };

                _logger.LogInformation("Sending email verification to {Email}", emailDto.Email);

                await _resend.EmailSendAsync(message, cancellationToken);

                _logger.LogInformation("Email verification sent to {Email} successfully", emailDto.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email verification to {Email}", emailDto.Email);
                throw;
            }
        }

        public async Task SendPasswordResetAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            try
            {
                var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
                var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

                var link = $"{ApiBaseUrl}UsersAuths/reset-password?email={encodedEmail}&token={encodedToken}";
               

                var message = new EmailMessage
                {
                    From = "onboarding@resend.dev",
                    To = { emailDto.Email },
                    Subject = "Password Reset | IconBuilderAI",
                    HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Reset your password<strong></a></div>"
                };

                _logger.LogInformation("Sending password reset email to {Email}", emailDto.Email);

                await _resend.EmailSendAsync(message, cancellationToken);

                _logger.LogInformation("Password reset email sent to {Email} successfully", emailDto.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending password reset email to {Email}", emailDto.Email);
                throw;
            }
        }
        public async Task SendPasswordChangedNotificationAsync(string email, CancellationToken cancellationToken)
{
    try
    {
        var message = new EmailMessage
        {
            From = "onboarding@resend.dev",
            To = { email},
            Subject = "Password Changed | IconBuilderAI",
            HtmlBody = "<div>Your password has been changed. If you did not initiate this change, please contact our support team immediately.</div>"
        };
        _logger.LogInformation("Sending password changed notification to {Email}", email);
        await _resend.EmailSendAsync(message, cancellationToken);
        _logger.LogInformation("Password changed notification sent to {Email} successfully", email);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error sending password changed notification to {Email}", email);
        throw;
    }
}
    }
}
