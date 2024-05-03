using TwitterApi.Bussines.Dtos.UserDtos;

namespace TwitterApi.Bussines.ExternalServices.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailConfirmedAsync(UserDto user);
        Task SendForgotPasswordMailAsync(UserDto user, string token);

    }
}
