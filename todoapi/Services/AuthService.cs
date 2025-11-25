using System.Security.Authentication;
using Microsoft.AspNetCore.Identity;
using todoapi.Dto;
using todoapi.Models;
using todoapi.Repositories;

namespace todoapi.Services;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        ITokenService tokenService,
        IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse?> Login (User user)
    {
        var user1 = await _userRepository.GetUser(user.Id);
        if(_passwordHasher.VerifyHashedPassword(null, user1.Password, user.Password) == PasswordVerificationResult.Failed)
            throw new AuthenticationException();    
        if (user1 == null)
            throw new AuthenticationException("Invalid user");
        var token = _tokenService.GenerateToken(user1);
        return new AuthResponse(token);
    }

    public async Task<int> Register(UserRequest model)
    {
        return await _userRepository.CreateUser(model);
    }
}