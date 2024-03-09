using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ReponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarsQuery
{
    public class GetCarsQueryHandler(
        IValidator<GetCarsQuery> validator,
        IUsersRepository usersRepository,
        ICarsRepository carsRepository,
        IMapper mapper
        ) : IRequestHandler<GetCarsQuery, Result<List<CarResponse>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GetCarsQuery> _validator = validator;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;
        public async Task<Result<List<CarResponse>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result<List<CarResponse>>.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
            var cars = await _carsRepository.GetCarsAsync(user.Role.Name, cancellationToken);

            var carsReponse = _mapper.Map<List<CarResponse>>(cars);
            return Result<List<CarResponse>>.Success(carsReponse);
        }
    }
}