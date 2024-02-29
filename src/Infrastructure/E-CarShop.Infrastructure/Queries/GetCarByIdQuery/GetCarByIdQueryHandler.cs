using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ReponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarByIdQuery
{
    public class GetCarByIdQueryHandler(
        IValidator<GetCarByIdQuery> validator,
        ICarsRepository carsRepository,
        IMapper mapper
        ) : IRequestHandler<GetCarByIdQuery, Result<CarResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICarsRepository _carsRepository = carsRepository;
        private readonly IValidator<GetCarByIdQuery> _validator = validator;
        public async Task<Result<CarResponse>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<CarResponse>.Invalid(validationResult.AsErrors());

            var car = await _carsRepository.GetByIdAsync(request.Id);
            var carResponse = _mapper.Map<CarResponse>(car);

            return Result<CarResponse>.Success(carResponse);
        }
    }
}