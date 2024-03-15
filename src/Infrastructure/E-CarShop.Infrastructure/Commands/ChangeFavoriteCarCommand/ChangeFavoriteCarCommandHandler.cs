using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.ChangeFavoriteCarCommand
{
    public class ChangeFavoriteCarCommandHandler(
        IMapper mapper,
        ICarsRepository carsRepository,
        IUsersRepository usersRepository,
        IValidator<ChangeFavoriteCarCommand> validator
        ) : IRequestHandler<ChangeFavoriteCarCommand, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly IValidator<ChangeFavoriteCarCommand> _validator = validator;
        public async Task<Result<CarResponse>> Handle(ChangeFavoriteCarCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
            var car = await _carsRepository.GetByIdAsync(request.CarId, cancellationToken);

            if (user == null || car == null)
                return Result.NotFound();

            if (!user.Cars.Contains(car))
                user.Cars.Add(car);
            else
                user.Cars.Remove(car);

            await _usersRepository.UpdateAsync(user, cancellationToken);
            var carResponse = _mapper.Map<CarResponse>(car);

            return Result<CarResponse>.Success(carResponse);
        }
    }
}