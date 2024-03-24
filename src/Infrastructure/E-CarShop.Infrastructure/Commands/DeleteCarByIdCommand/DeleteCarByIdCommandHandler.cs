using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.DeleteCarByIdCommand
{
    public class DeleteCarByIdCommandHandler(
        IMapper mapper,
        ICarsRepository carsRepository,
        IValidator<DeleteCarByIdCommand> validator
        ) : IRequestHandler<DeleteCarByIdCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IValidator<DeleteCarByIdCommand> _validator = validator;
        public async Task<Result<CarResponse>> Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<CarResponse>.Invalid(validationResult.AsErrors());

            var car = await _carsRepository.GetByIdAsync(request.Id, cancellationToken);
            if (car == null)
                return Result.NotFound($"Машины с Id:{request.Id} не найдено");

            var removedCar = await _carsRepository.DeleteByIdAsync(request.Id, cancellationToken);
            var removedCarResponse = _mapper.Map<CarResponse>(removedCar);

            return Result<CarResponse>.Success(removedCarResponse);
        }
    }
}
