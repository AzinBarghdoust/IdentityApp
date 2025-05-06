using IdentityApp.DTOs.Account;
using MediatR;

namespace IdentityApp.Application.Accounts.Commands
{
    public record LoginCommand(string UserName, string Password) : IRequest<UserDto>;

}
