﻿using E_CarShop.Infrastructure.Queries.GetCarByIdQuery;
using E_CarShop.Infrastructure.Queries.GetCarsQuery;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using E_CarShop.Core.Shared;
using MediatR;

namespace E_CarShop.Web.Controllers
{
    public class CarsController(
        IMediator mediator,
        IHttpContextAccessor httpContextAccessor
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        [HttpGet]
        public async Task<IActionResult> GetById([Required][FromHeader] int id)
        {
            var userId = int.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value);
            return (await _mediator.Send(new GetCarByIdQuery(id, userId))).ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromHeader] int pageNumber = 1)
        {
            var userId = int.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value);
            return (await _mediator.Send(new GetCarsQuery(pageNumber, userId))).ToActionResult();
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