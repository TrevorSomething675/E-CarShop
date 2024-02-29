using E_CarShop.Infrastructure.Queries.GetCarByIdQuery;
using E_CarShop.Infrastructure.Queries.GetCarsQuery;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using E_CarShop.Core.Shared;
using MediatR;

namespace E_CarShop.Web.Controllers
{
    public class CarsController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetById([Required] int id)
        {
            return (await _mediator.Send(new GetCarByIdQuery(id))).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1)
        {
            return (await _mediator.Send(new GetCarsQuery(pageNumber))).ToActionResult();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}