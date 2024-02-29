using E_CarShop.Core.ConfigurationModels;
using System.IdentityModel.Tokens.Jwt;
using E_CarShop.Application.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using E_CarShop.Core.Shared;
using System.Text;

namespace E_CarShop.Infrastructure.Services
{
    public class TokenService(
        IOptions<JwtAuthOptions> options
        ) : ITokenService
    {
        private readonly JwtAuthOptions _options = options.Value;
        public async Task<JwtTokensModel> GetTokens(string Role)
        {
            var tokens = new JwtTokensModel
            {
                AccessToken = await CreateAccessToken(Role),
                RefreshToken = await CreateRefreshToken(Role)
            };
            return tokens;
        }
        public async Task<JwtTokensModel> GetTokensOnRefreshToken(string refreshToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtRefreshToken = handler.ReadJwtToken(refreshToken);
            var role = handler.ReadJwtToken(refreshToken).Claims.FirstOrDefault(t => t.Value == "Role").Value;

            var tokens = new JwtTokensModel
            {
                AccessToken = await CreateAccessToken(role),
                RefreshToken = await CreateRefreshToken(role)
            };
            return tokens;
        }
        private async Task<string> CreateAccessToken(string Role)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, Role),
                };
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpAccessTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private async Task<string> CreateRefreshToken(string Role)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role, Role),
                };
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpRefreshTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}