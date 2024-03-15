using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.CreateCarCommand
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator() 
        {
            RuleFor(command => command.Name)
                .NotNull().NotEmpty();

            RuleFor(command => command.Color)
                .NotNull().NotEmpty();

            RuleFor(command => command.Description)
                .NotNull().NotEmpty();

            RuleFor(command => command.Price)
                .NotNull().NotEmpty();

            RuleFor(command => command.BrandId)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();
        }
    }
}