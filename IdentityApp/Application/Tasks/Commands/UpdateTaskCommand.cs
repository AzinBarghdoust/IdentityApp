using System.Threading.Tasks;
using System;
using MediatR;
using IdentityApp.Application.Common.Responses;

namespace IdentityApp.Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
    }
}
