using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Queries.GetCarsQuery
{
    public class GetCarsQueryValidator : AbstractValidator<GetCarsQuery>
    {
        public GetCarsQueryValidator()
        {
            RuleFor(query => query.UserId)
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом");
        }
    }
}