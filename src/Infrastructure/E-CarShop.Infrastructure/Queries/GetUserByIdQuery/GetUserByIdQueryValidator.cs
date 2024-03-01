using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator() 
        {
            RuleFor(query => query.Id)
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом")
                .NotNull().NotEmpty();
        }
    }
}