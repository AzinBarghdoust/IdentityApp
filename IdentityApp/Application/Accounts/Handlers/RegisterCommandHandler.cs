using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityApp.Application.Accounts.Commands;
using IdentityApp.Domain.Entities;
using IdentityApp.DTOs.Account;
using IdentityApp.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Application.Accounts.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly JWTService _jwtService;

        public RegisterCommandHandler(UserManager<User> userManager, JWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == request.Email.ToLower(), cancellationToken);
            if (exists)
            {
                throw new UnauthorizedAccessException("Email already exists, please try another one.");
            }

            var user = new User
            {
                FirstName = request.FirstName.ToLower(),
                LastName = request.LastName.ToLower(),
                UserName = request.Email.ToLower(),
                Email = request.Email.ToLower(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
               
                throw new Exception("Registration failed");
            }

            return new UserDto
            {
                FristName = user.FirstName,
                LastName = user.LastName,
                JWT = _jwtService.CreateJWT(user)
            };
        }
    }
}

