using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.RequestModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.CreateCarCommand
{
    public class CreateCarCommand : IRequest<Result<CarResponse>>
    {
        public CarRequest CarToCreate { get; set; }
    }
}