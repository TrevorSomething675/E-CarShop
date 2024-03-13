using E_CarShop.Infrastructure.Commands.GetTokensCommand;
using System.ComponentModel.DataAnnotations;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using E_CarShop.Core.Shared;
using MediatR;

namespace E_CarShop.Web.Controllers
{
    public class AuthController(
        IMediator mediator
        ) : Controller
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetTokens([Required][FromHeader] GetTokensCommand command, CancellationToken cancellationToken = default)
        {
            return (await _mediator.Send(command, cancellationToken)).ToActionResult();
        }
    }
}