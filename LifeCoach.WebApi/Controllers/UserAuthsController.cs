using LifeCoach.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeCoach.WebApi;
 [Route("api/[controller]")]
    [ApiController]
public class UserAuthsController(ISender mediatr) : ControllerBase
{
      private readonly ISender _mediatr = mediatr;

  [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }
          [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmailAsync([FromQuery] UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet("forgot-password")]
        public async Task<IActionResult> ForgotPasswordAsync([FromQuery]ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediatr.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordAsync([FromQuery]ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediatr.Send(command, cancellationToken);
            return Ok(result);
        }
        [Authorize]
          [HttpPost("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromQuery] ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediatr.Send(command, cancellationToken);
            return Ok(result);
        }
}
