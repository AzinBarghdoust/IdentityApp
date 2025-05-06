using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityApp.Application.Accounts.Commands;
using IdentityApp.Application.Accounts.Queries;
using IdentityApp.DTOs.Account;
using IdentityApp.Domain.Entities;
using IdentityApp.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
       
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [Authorize]
        [HttpGet("refresh-user-token")]
        public async Task<ActionResult<UserDto>> RefreshUserToken()
        {
            var result = await _mediator.Send(new RefreshTokenQuery(User));
            return Ok(result);
        
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            try
            {
                var result = await _mediator.Send(new LoginCommand(model.UserName, model.Password));
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);

            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
