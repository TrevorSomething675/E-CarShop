using E_CarShop.Core.Shared;

namespace E_CarShop.Application.Services
{
    public interface ITokenService
    {
        public Task<JwtTokensModel> GetTokens(string Role);
        public Task<JwtTokensModel> GetTokensOnRefreshToken(string refreshToken);
    }
}