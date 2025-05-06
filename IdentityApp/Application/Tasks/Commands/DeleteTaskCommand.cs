using System;
using IdentityApp.Application.Common.Responses;
using MediatR;

namespace IdentityApp.Application.Tasks.Commands
{
    public record DeleteTaskCommand(Guid Id ) : IRequest<Response<Guid>>;
    
}
