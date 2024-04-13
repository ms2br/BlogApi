using TwitterApi.Bussines.Dtos.TokenDtos;

namespace TwitterApi.Bussines.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> CreateAccessTokenAsync(double hours);
    }
}
