using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto dto);
        Task ForgotPassworAsync(string email);

        Task<bool> VerifyResetPasswordTokenAsync(AppUser user, string token);
        Task<bool> VerifyEmailConfirmedTokenAsync(AppUser user, string token);
    }
}
