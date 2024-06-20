using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterApi.Bussines.Dtos.TokenDtos;
using TwitterApi.Bussines.ExternalServices.Interfaces;
using TwitterApi.Core.Enums;

namespace TwitterApi.Bussines.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _configuration { get; }
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TokenDto> CreateAccessTokenAsync(TokenParamsDto tokenDto)
        {
            TokenDto token = new();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256); 
            token.Expiration = DateTime.UtcNow.AddHours(tokenDto.Hours);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, tokenDto.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, tokenDto.AppUser.Id));
            JwtSecurityToken securityToken = new
                (
                  audience: _configuration.GetSection("Token")?["Audience"],
                  issuer: _configuration["Token:Issuer"],
                  expires: token.Expiration,
                  notBefore: DateTime.UtcNow,
                  signingCredentials: signingCredentials,
                  claims: claims
                );
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
