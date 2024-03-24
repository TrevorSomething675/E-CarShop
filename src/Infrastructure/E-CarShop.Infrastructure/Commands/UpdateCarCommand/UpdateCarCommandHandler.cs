using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.Models;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.UpdateCarCommand
{
    public class UpdateCarCommandHandler(
        IMapper mapper,
        ICarsRepository carsRepository,
        IValidator<UpdateCarCommand> validator
        ) : IRequestHandler<UpdateCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IValidator<UpdateCarCommand> _validator = validator;
        public async Task<Result<CarResponse>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Invalid(validationResult.AsErrors());

            var car = await _carsRepository.GetByIdAsync(request.CarToUpdate.Id, cancellationToken);
            if (car == null)
                return Result<CarResponse>.NotFound($"Автомобиль с Id:{request.CarToUpdate.Id} не найден");

            var carToUpdate = _mapper.Map<Car>(request.CarToUpdate);
            var updatedCar = await _carsRepository.UpdateAsync(carToUpdate, cancellationToken);
            var updatedСarResponse = _mapper.Map<CarResponse>(updatedCar);

            return Result<CarResponse>.Success(updatedСarResponse);
        }
    }
}