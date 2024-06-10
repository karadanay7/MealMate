namespace LifeCoach.Application;

 public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken);
        Task<bool> VerifyEmailAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken);
        Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken);
        Task ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellationToken);
      Task<bool> ChangePasswordAsync( Guid userId, string newPassword, string currentPassword, CancellationToken cancellationToken);
    }