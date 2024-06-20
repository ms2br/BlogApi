using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Web;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Enums;
namespace TwitterApi.Bussines.Services.Implements
{
    public class AuthService : IAuthService
    {
        SignInManager<AppUser> _sm { get; }
        UserManager<AppUser> _um { get; }
        RoleManager<IdentityRole> _rm { get; }
        ITokenService _token { get; }
        IEmailService _email { get; }
        IMapper _mapper { get; }
        IConfiguration _configuration { get; }
        
        public AuthService(SignInManager<AppUser> sm,
            UserManager<AppUser> um,
            ITokenService token,
            IEmailService email,
            IMapper mapper,
            RoleManager<IdentityRole> rm,
            IConfiguration configuration)
        {
            _sm = sm;
            _um = um;
            _token = token;
            _email = email;
            _mapper = mapper;
            _rm = rm;
            _configuration = configuration;
        }

        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            AppUser user = dto switch
            {
                var item when item.UserNameOrEmail.Contains("@") => await _um.FindByEmailAsync(dto.UserNameOrEmail),
                _ => await _um.FindByNameAsync(dto.UserNameOrEmail)
            };
            ObjectNullChecking(user);
            var signInResult = await _um.CheckPasswordAsync(user, dto.Password);
            if (!signInResult)
                throw new AuthenticationException();
            var userRole = await _um.GetRolesAsync(user);


            return await _token.CreateAccessTokenAsync(new TokenParamsDto
            {
                AppUser = user,
                Role = userRole[0],
                Hours = Convert.ToDouble(_configuration["Token:LifeSpan"])
            });
        }

        public async Task ForgotPassworAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new NotFoundUserException();
            var user = await _um.FindByEmailAsync(email);
            ObjectNullChecking(user);
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

        void ObjectNullChecking(AppUser appUser)
        {
            if (appUser == null)
                throw new NotFoundUserException();
        }
    }
}
