using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Queries.GetUsersQuery
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator() 
        {
            RuleFor(query => query.PageNumber)
                .Must(CheckField.IsNumber)
                .NotNull().NotEmpty();
        }
    }
}