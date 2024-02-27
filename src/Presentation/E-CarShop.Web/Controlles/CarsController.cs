using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace E_CarShop.Web.Controlles
{
    public class CarsControllers(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public async Task<IActionResult> Update()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
    }
}