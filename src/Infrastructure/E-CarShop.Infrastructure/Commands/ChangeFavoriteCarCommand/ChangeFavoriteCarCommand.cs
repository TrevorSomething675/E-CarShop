using E_CarShop.Core.ResponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.ChangeFavoriteCarCommand
{
    public class ChangeFavoriteCarCommand(int carId, int userId) : IRequest<Result<CarResponse>> 
    {
        public int CarId { get; } = carId;
        public int UserId { get; } = userId;
    }
}