using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.DeleteCarByIdCommand
{
    public class DeleteCarByIdCommandValidator : AbstractValidator<DeleteCarByIdCommand>
    {
        public DeleteCarByIdCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");
        }
    }
}