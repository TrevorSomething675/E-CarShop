﻿using E_CarShop.Core.Shared;
using FluentValidation;

namespace E_CarShop.Infrastructure.Queries.GetCarByIdQuery
{
    public class GetCarByIdQueryValidator : AbstractValidator<GetCarByIdQuery>
    {
        public GetCarByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .Must(CheckField.IsNumber).WithMessage("Id должен быть числом")
                .NotNull().NotEmpty();
        }
    }
}