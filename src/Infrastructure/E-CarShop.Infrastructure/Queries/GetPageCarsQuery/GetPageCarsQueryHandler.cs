using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Application.Services;
using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.Models;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetPageCarsQuery
{
    public class GetPageCarsQueryHandler(
        IMapper mapper,
        ICarsRepository carsRepository,
        IUsersRepository usersRepository,
        IValidator<GetPageCarsQuery> validator,
        IMinioService minioService
        ) : IRequestHandler<GetPageCarsQuery, Result<List<CarResponse>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMinioService _minioService = minioService;
        private readonly IValidator<GetPageCarsQuery> _validator = validator;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;
        public async Task<Result<List<CarResponse>>> Handle(GetPageCarsQuery request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<List<CarResponse>>.Invalid(validationResult.AsErrors());

            var cars = new List<Car>();
            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user == null)
                cars = await _carsRepository.GetPageCarsAsync(1, "User", cancellationToken);
            else
                cars = await _carsRepository.GetPageCarsAsync(request.PageNumber, user.Role.Name, cancellationToken);

            foreach (var car in cars)
            {
                foreach (var image in car.Images)
                {
                    image.Base64String = await _minioService.GetObjectByNameAsync(image.Path);
                }
            }
            var carsResponse = _mapper.Map<List<CarResponse>>(cars);

            return Result<List<CarResponse>>.Success(carsResponse);
        }
    }
}