﻿using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarByIdQuery
{
    public class GetCarByIdQueryHandler(
        IValidator<GetCarByIdQuery> validator,
        IUsersRepository usersRepository,
        ICarsRepository carsRepository,
        IMapper mapper
        ) : IRequestHandler<GetCarByIdQuery, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IValidator<GetCarByIdQuery> _validator = validator;
        private readonly IUsersRepository _usersRepository = usersRepository;
        public async Task<Result<CarResponse>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<CarResponse>.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
            if (user == null)
                return Result<CarResponse>.Unauthorized();

            var car = await _carsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (car == null)
                return Result<CarResponse>.NotFound("Машина не найдена");

            var carResponse = _mapper.Map<CarResponse>(car);
            return Result<CarResponse>.Success(carResponse);
        }
    }
}