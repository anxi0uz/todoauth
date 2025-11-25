using todoapi.Models;

namespace todoapi.Services;

public interface ITokenService
{
    string GenerateRefreshToken();
    string GenerateToken(User user);
}