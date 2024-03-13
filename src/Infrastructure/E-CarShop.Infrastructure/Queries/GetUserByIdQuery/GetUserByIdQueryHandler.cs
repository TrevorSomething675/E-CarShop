using E_CarShop.Application.Repositories;
using Ardalis.Result.FluentValidation;
using E_CarShop.Core.ReponseModels;
using FluentValidation;
using Ardalis.Result;
using AutoMapper;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetUserByIdQuery
{
    public class GetUserByIdQueryHandler(
        IMapper mapper,
        IUsersRepository usersRepository,
        IValidator<GetUserByIdQuery> validator
        ) : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly IValidator<GetUserByIdQuery> _validator = validator;
        public async Task<Result<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return Result<UserResponse>.Invalid(validationResult.AsErrors());

            var user = await _usersRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
                return Result<UserResponse>.NotFound("Пользователь не найден");

            return _mapper.Map<UserResponse>(user);
        }
    }
}