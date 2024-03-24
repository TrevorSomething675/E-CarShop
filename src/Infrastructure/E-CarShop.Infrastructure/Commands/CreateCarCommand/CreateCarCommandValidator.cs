using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.CreateCarCommand
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.CarToCreate)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToCreate.Name)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToCreate.Color)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToCreate.Description)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToCreate.Price)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToCreate.BrandId)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();
        }
    }
}