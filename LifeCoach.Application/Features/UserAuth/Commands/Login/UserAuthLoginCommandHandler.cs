using LifeCoach.Application;

using MediatR;




public class UserAuthLoginCommandHandler : IRequestHandler<UserAuthLoginCommand, ResponseDto<JwtDto>>
{
    private readonly IIdentityService _identityService;
    private readonly IJwtService _jwtService;

    public UserAuthLoginCommandHandler(IIdentityService identityService , IJwtService jwtService)
    {
        _identityService = identityService;
        _jwtService = jwtService;
       
    }

    public async Task<ResponseDto<JwtDto>> Handle(UserAuthLoginCommand request, CancellationToken cancellationToken)
    {
        var jwtDto = await _identityService.LoginAsync(request, cancellationToken);
        
        return new ResponseDto<JwtDto>(jwtDto, "Login successful");
    }
}
