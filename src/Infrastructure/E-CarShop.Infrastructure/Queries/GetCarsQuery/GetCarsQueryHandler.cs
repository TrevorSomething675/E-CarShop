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
        IMapper mapper,
        ICarsRepository carsRepository,
        IValidator<GetCarsQuery> validator
        ) : IRequestHandler<GetCarsQuery, Result<List<CarResponse>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GetCarsQuery> _validator = validator;
        private readonly ICarsRepository _carsRepository = carsRepository;
        public async Task<Result<List<CarResponse>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<List<CarResponse>>.Invalid(validationResult.AsErrors());

            var cars = _carsRepository.GetCarsAsync(request.PageNumber);
            var carsResponse = _mapper.Map<List<CarResponse>>(cars);

            return Result<List<CarResponse>>.Success(carsResponse);
        }
    }
}