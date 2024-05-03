using System.Security.Claims;
using TwitterApi.Bussines.Dtos.UserDtos;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(RegisterDto dto);
        Task ChangePassworAsync(ChangePassworDto dto, ClaimsPrincipal user);
        Task UpdatePasswordAsync(UpdatePasswordDto dto);
        Task EmailConfirmedAsync(string userId, string token);
    }
}
