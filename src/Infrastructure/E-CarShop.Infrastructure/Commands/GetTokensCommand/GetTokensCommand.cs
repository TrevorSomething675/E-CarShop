using E_CarShop.Core.Shared;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.GetTokensCommand
{
    public class GetTokensCommand(int userId, string role) : IRequest<Result<JwtTokensModel>>
    {
        public int UserId { get; } = userId;
        public string Role { get; } = role;
    }
}