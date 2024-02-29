using E_CarShop.Core.ReponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarByIdQuery
{
    public class GetCarByIdQuery(int id) : IRequest<Result<CarResponse>>
    {
        public int Id { get; } = id;
    }
}