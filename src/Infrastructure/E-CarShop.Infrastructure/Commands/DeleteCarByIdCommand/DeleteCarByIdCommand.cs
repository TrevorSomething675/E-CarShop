using E_CarShop.Core.ResponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Commands.DeleteCarByIdCommand
{
    public class DeleteCarByIdCommand(int id) : IRequest<Result<CarResponse>>
    {
        public int Id { get; } = id;
    }
}