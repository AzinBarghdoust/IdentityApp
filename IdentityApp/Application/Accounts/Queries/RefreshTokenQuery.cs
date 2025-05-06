using System.Security.Claims;
using IdentityApp.DTOs.Account;
using MediatR;

namespace IdentityApp.Application.Accounts.Queries
{
    public class RefreshTokenQuery : IRequest<UserDto>
    {
        public ClaimsPrincipal User { get; set; }
        public RefreshTokenQuery(ClaimsPrincipal user)
        { 
            User = user;
        }
    }
}
