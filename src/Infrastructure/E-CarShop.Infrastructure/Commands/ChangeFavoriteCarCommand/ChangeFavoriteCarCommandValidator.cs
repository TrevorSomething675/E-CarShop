using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.ChangeFavoriteCarCommand
{
    public class ChangeFavoriteCarCommandValidator : AbstractValidator<ChangeFavoriteCarCommand>
    { 
        public ChangeFavoriteCarCommandValidator()
        {
            RuleFor(command => command.CarId)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();
        }
    }
}
