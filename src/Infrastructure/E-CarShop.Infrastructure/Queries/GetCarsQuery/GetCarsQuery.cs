using E_CarShop.Core.ReponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarsQuery
{
    public class GetCarsQuery(int pageNumber) : IRequest<Result<List<CarResponse>>>
    {
        public int PageNumber { get; } = pageNumber;
    }
}