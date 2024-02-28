using E_CarShop.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using E_CarShop.Core.Models;

namespace E_CarShop.Web.Controllers
{
    public class CarsController(
        IMediator mediator,
        ICarRepository carRepository,
        IUserRepository userRepository
        ) : Controller
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ICarRepository _carRepository = carRepository;
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
            var car = (await _carRepository.GetCarsAsync()).FirstOrDefault();
            var image = new Image
            {
                Name = "jfiads",
                Path = "fsdf"
            };
            car.Images.Add(image);
            var result = await _carRepository.UpdateAsync(car);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _carRepository.DeleteByIdAsync(2);
            return Ok();
        }
    }
}