using System.Web;
using LifeCoach.Application;
using LifeCoach.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LifeCoach.Infrastructure;

public class IdentityManager:IIdentityService
{
     private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;
           public IdentityManager(UserManager<User> userManager, IJwtService jwtService, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _currentUserService = currentUserService;
        }
           public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);

            var result = await _userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return new UserAuthRegisterResponseDto(user.Id, user.Email, user.FirstName, token);


        }
          public async Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);

            return jwtDto;
        }

        public async Task<bool> IsEmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return true;

            return false;
        }
        
        public async Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return false;

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> VerifyEmailAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            var result = await _userManager.ConfirmEmailAsync(user, command.Token);

            if (!result.Succeeded)
            {
                throw new Exception("User's email verification failed");
            }

            return true;
        }

        public Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email && x.EmailConfirmed, cancellationToken);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }


        public async Task ResetPasswordAsync(string email, string token, string newPassword, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var decodedToken = HttpUtility.UrlDecode(token);

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, newPassword);
            if (result.Succeeded)
            {

            }
            if (!result.Succeeded)
            {
                throw new Exception("Password reset failed");
            }
        }

  
        public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, CancellationToken cancellationToken)
        {
             var user=await _userManager.FindByIdAsync(userId.ToString());
              var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Password reset failed");
            }

            return true;


        }


}
