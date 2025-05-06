using System;
using IdentityApp.Application.Common.Responses;
using MediatR;

namespace IdentityApp.Application.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<Response<Guid>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
