using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.Models;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.CreateCarCommand
{
    public class CreateCarCommandHandler(
        IMapper mapper,
        ICarsRepository carsRepository,
        IBrandRepository brandRepository,
        IValidator<CreateCarCommand> validator
        ) : IRequestHandler<CreateCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IBrandRepository _brandRepository = brandRepository;
        private readonly IValidator<CreateCarCommand> _validator = validator;
        public async Task<Result<CarResponse>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result<CarResponse>.Invalid(validationResult.AsErrors());

            var carToCreate = _mapper.Map<Car>(request.CarToCreate);
            var brand = await _brandRepository.GetBrandById(carToCreate.BrandId);
            if (brand == null)
                return Result<CarResponse>.NotFound($"Бренд с Id:{carToCreate.BrandId} не найден");
            else
                carToCreate.Brand = brand;

            var createdCar = await _carsRepository.CreateAsync(carToCreate, cancellationToken);
            var createdCarResponse = _mapper.Map<Car, CarResponse>(createdCar);

            return Result<CarResponse>.Success(createdCarResponse);
        }
    }
}