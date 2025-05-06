using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System;
using IdentityApp.Application.Accounts.Queries;
using IdentityApp.DTOs.Account;
using IdentityApp.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using IdentityApp.Domain.Entities;

namespace IdentityApp.Application.Accounts.Handlers
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly JWTService _jwtService;

        public RefreshTokenQueryHandler(UserManager<User> userManager, JWTService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserDto> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var email = request.User.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
                throw new UnauthorizedAccessException("User is not authenticated.");

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new UnauthorizedAccessException("User not found.");

            return new UserDto
            {
                FristName = user.FirstName,
                LastName = user.LastName,
                JWT = _jwtService.CreateJWT(user)
            };
        }
    }
}
