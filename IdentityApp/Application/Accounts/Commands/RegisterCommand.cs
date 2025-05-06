using IdentityApp.DTOs.Account;
using MediatR;

namespace IdentityApp.Application.Accounts.Commands
{
    public class RegisterCommand : IRequest<UserDto>
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
}

