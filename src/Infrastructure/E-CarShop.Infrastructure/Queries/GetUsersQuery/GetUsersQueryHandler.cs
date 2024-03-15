using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ResponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetUsersQuery
{
    public class GetUsersQueryHandler(
        IMapper mapper,
        IUsersRepository usersRepository,
        IValidator<GetUsersQuery> validator
        ) : IRequestHandler<GetUsersQuery, Result<List<UserResponse>>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<GetUsersQuery> _validator = validator;
        private readonly IUsersRepository _usersRepository = usersRepository;
        public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result<List<UserResponse>>.Invalid(validationResult.AsErrors());

            var users = await _usersRepository.GetUsersAsync(request.PageNumber, cancellationToken);

            if (users == null)
                return Result<List<UserResponse>>.NotFound();

            return Result<List<UserResponse>>.Success(_mapper.Map<List<UserResponse>>(users));
        }
    }
}