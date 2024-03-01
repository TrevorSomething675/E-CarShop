using E_CarShop.Infrastructure.Queries.GetUserByIdQuery;
using E_CarShop.Infrastructure.Queries.GetUsersQuery;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using E_CarShop.Core.Shared;
using MediatR;

namespace E_CarShop.Web.Controllers
{
    public class UsersController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetById([Required][FromHeader] int id)
        {
            return (await _mediator.Send(new GetUserByIdQuery(id))).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader] int pageNumber = 1)
        {
            return (await _mediator.Send(new GetUsersQuery(pageNumber))).ToActionResult();
        }
    }
}
