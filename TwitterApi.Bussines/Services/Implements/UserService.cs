using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.Web;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Services.Implements
{
    public class UserService : IUserService
    {
        IMapper _mapper { get; }
        UserManager<AppUser> _um { get; }
        IEmailService _email { get; }
        IAuthService _auth { get; }

        public UserService(IMapper mapper, UserManager<AppUser> um, IEmailService email, IAuthService auth)
        {
            _mapper = mapper;
            _um = um;
            _email = email;
            _auth = auth;
        }

        public async Task CreateUserAsync(RegisterDto dto)
        {
            AppUser appUser = _mapper.Map<AppUser>(dto);
            if (dto.ImgUrl != null)
            {
                if (!dto.ImgUrl.IsValidSize())
                    throw new InValidSizeException(ExceptionMessages.InValidSizeMessage);

                if (!dto.ImgUrl.IsCorrectType())
                    throw new InCorrectTypeException(ExceptionMessages.InCorrectTypeMessage);
                appUser.ImgUrl = (await dto.ImgUrl.SaveAsync(PathConstants.UserImg)).Item1;
            }
            IdentityResult result = await _um.CreateAsync(appUser, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder messages = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    messages.Append(item.Description + " ");
                }
                throw new IdentityResultException(messages.ToString().TrimEnd());
            }
            string token = await _um.GenerateEmailConfirmationTokenAsync(appUser);
            await _email.SendEmailConfirmedAsync(_mapper.Map<UserDto>(appUser));
        }

        public async Task ChangePassworAsync(ChangePassworDto dto, ClaimsPrincipal user)
        {
            AppUser appUser = await _um.GetUserAsync(user);
            UserChecking(appUser);
            IdentityResult identityResult = await _um.ChangePasswordAsync(appUser, dto.CurrentPassword, dto.NewPassword);

            if (!identityResult.Succeeded)
                throw new IdentityResultException("Wrong Password");
        }

        public async Task EmailConfirmedAsync(string userId, string token)
        {
            AppUser appUser = _um.FindByIdAsync(userId).Result;
            if (!await _auth.VerifyEmailConfirmedTokenAsync(appUser, token))
                throw new IdentityResultException("Email verification failed.");
            IdentityResult result = await _um.ConfirmEmailAsync(appUser,
            HttpUtility.UrlDecode(token));
            if (!result.Succeeded)
                throw new IdentityResultException("Email verification failed.");
        }

        public async Task UpdatePasswordAsync(UpdatePasswordDto dto)
        {
            AppUser appUser = await _um.FindByIdAsync(dto.UserId);
            if (!await _auth.VerifyResetPasswordTokenAsync(appUser, dto.Token))
                throw new PasswordChangeFailedException();
            UserChecking(appUser);
            var result = await _um.ResetPasswordAsync(appUser, dto.Token, dto.Password);
            if (!result.Succeeded)
                throw new PasswordChangeFailedException();
            await _um.GenerateConcurrencyStampAsync(appUser);
        }

        void UserChecking(AppUser appUser)
        {
            if (appUser == null)
                throw new NotFoundUserException();
        }
    }
}
