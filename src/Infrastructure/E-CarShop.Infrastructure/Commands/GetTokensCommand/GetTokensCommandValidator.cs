using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.GetTokensCommand
{
    public class GetTokensCommandValidator : AbstractValidator<GetTokensCommand>
    {
        public GetTokensCommandValidator() 
        {
            RuleFor(command => command.UserId)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();

            RuleFor(command => command.Role)
                .NotNull().NotEmpty();
        }
    }
}