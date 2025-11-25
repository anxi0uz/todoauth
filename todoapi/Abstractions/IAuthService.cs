using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Services;

public interface IAuthService
{
    Task<AuthResponse?> Login (User user);
    Task<int> Register(UserRequest model);
}