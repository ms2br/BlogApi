using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Web;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities.Identity;
namespace TwitterApi.Bussines.Services.Implements
{
    public class AuthService : IAuthService
    {
        SignInManager<AppUser> _sm { get; }
        UserManager<AppUser> _um { get; }
        ITokenService _token { get; }
        IEmailService _email { get; }
        IMapper _mapper { get; }

        public AuthService(SignInManager<AppUser> sm,
            UserManager<AppUser> um,
            ITokenService token,
            IEmailService email,
            IMapper mapper)
        {
            _sm = sm;
            _um = um;
            _token = token;
            _email = email;
            _mapper = mapper;
        }

        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            AppUser user = dto switch
            {
                var item when item.UserNameOrEmail.Contains("@") => await _um.FindByEmailAsync(dto.UserNameOrEmail),
                _ => await _um.FindByNameAsync(dto.UserNameOrEmail)
            };

            UserChecking(user);

            var signInResult = await _sm.PasswordSignInAsync(user, dto.Password, dto.IsRemember, true);
            if (!signInResult.Succeeded)
                throw new AuthenticationErrorException();
            return await _token.CreateAccessTokenAsync(5);
        }

        public async Task ForgotPassworAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new NotFoundUserException();
            var user = await _um.FindByEmailAsync(email);
            UserChecking(user);
            string resetToken = await _um.GeneratePasswordResetTokenAsync(user);
            resetToken = HttpUtility.UrlEncode(resetToken);
            await _email.SendForgotPasswordMailAsync(_mapper.Map<UserDto>(user), resetToken);
        }

        public async Task<bool> VerifyResetPasswordTokenAsync(AppUser user, string token)
        {
            token = HttpUtility.UrlDecode(token);
            return await _um.VerifyUserTokenAsync(user, _um.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
        }

        public async Task<bool> VerifyEmailConfirmedTokenAsync(AppUser user, string token)
        {
            token = HttpUtility.UrlDecode(token);
            return await _um.VerifyUserTokenAsync(user, _um.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation", token);
        }

        void UserChecking(AppUser appUser)
        {
            if (appUser == null)
                throw new NotFoundUserException();
        }
    }
}
