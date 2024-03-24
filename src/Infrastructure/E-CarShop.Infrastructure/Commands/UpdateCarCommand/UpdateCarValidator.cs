using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Commands.UpdateCarCommand
{
    public class UpdateCarValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(command => command.CarToUpdate)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToUpdate.Id)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");

            RuleFor(command => command.CarToUpdate.Name)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToUpdate.Color)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToUpdate.Description)
                .NotNull().NotEmpty();

            RuleFor(command => command.CarToUpdate.Price)
                .NotNull().NotEmpty()
                .Must(CheckField.IsNumber).WithMessage("Цена должна быть числом");
        }
    }
}
