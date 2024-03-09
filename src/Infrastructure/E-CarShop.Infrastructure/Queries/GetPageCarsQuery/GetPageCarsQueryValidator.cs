using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Queries.GetPageCarsQuery
{
    public class GetPageCarsQueryValidator : AbstractValidator<GetPageCarsQuery>
    {
        public GetPageCarsQueryValidator() 
        {
            RuleFor(query => query.PageNumber)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();
        }
    }
}