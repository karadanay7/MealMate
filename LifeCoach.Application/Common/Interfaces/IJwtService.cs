using LifeCoach.Domain;

namespace LifeCoach.Application;

public interface IJwtService
{
   JwtDto GenerateTokenAsync(User user,List<string> roles);
 Task<JwtDto> GenerateTokenAsync(Guid userId, string email,CancellationToken cancellationToken);
}
