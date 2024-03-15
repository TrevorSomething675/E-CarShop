using E_CarShop.Core.ResponseModels;
using E_CarShop.Core.RequestModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.CreateCarCommand
{
    public class CreateCarCommand : IRequest<Result<CarResponse>>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<ImageRequest> Images { get; set; }
        public int BrandId { get; set; }
    }
}