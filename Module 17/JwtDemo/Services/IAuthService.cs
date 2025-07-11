using JwtDemo.DTOs;
using JwtDemo.Models;

namespace JwtDemo.Services
{
    public interface IAuthService
    {
        Task<User?> Register(UserDto request);
        Task<TokenResponseDto?> Login(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
