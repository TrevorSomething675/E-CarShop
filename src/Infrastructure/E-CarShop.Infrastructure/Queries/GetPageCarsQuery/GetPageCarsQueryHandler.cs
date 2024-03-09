using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Application.Services;
using E_CarShop.Core.ReponseModels;
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
        public async Task<Result<List<CarResponse>>> Handle(GetPageCarsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result<List<CarResponse>>.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);
            var role = user?.Role?.Name ?? "User";
            var cars = await _carsRepository.GetPageCarsAsync(request.PageNumber, role, cancellationToken);
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