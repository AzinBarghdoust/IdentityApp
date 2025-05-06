using IdentityApp.Application.Accounts.Commands;
using IdentityApp.DTOs.Account;
using IdentityApp.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;
using System;
using IdentityApp.Domain.Entities;

namespace IdentityApp.Application.Accounts.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTService _jwtService;

        public LoginCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, JWTService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null || !user.EmailConfirmed)
                throw new UnauthorizedAccessException("Invalid credentials or email not confirmed.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials.");

            return new UserDto
            {
                FristName = user.UserName,
                LastName = user.UserName,
                JWT = _jwtService.CreateJWT(user)
            };
        }
    }
}
