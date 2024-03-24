using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.RequestModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.UpdateCarCommand
{
    public class UpdateCarCommand : IRequest<Result<CarResponse>>
    {
        public CarRequest CarToUpdate { get; set; }
    }
}