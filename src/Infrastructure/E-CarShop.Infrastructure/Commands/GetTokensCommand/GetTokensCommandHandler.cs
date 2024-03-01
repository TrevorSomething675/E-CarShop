using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Application.Services;
using E_CarShop.Core.Shared;
using FluentValidation;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.GetTokensCommand
{
    public class GetTokensCommandHandler(
        ITokenService tokenService,
        IUsersRepository usersRepository,
        IValidator<GetTokensCommand> validator
        ) : IRequestHandler<GetTokensCommand, Result<JwtTokensModel>>
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly IValidator<GetTokensCommand> _validator = validator;
        public async Task<Result<JwtTokensModel>> Handle(GetTokensCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<JwtTokensModel>.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user == null || user.Role.Name != request.Role)
                return Result<JwtTokensModel>.NotFound("Неверный id пользователя или роль");
            
            var tokens = await _tokenService.GetTokens(request.Role);

            return Result<JwtTokensModel>.Success(tokens);
        }
    }
}