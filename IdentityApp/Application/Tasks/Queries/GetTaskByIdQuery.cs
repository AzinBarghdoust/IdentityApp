using IdentityApp.Application.Common.Responses;
using IdentityApp.Domain.Entities;
using MediatR;
using System;

namespace IdentityApp.Application.Tasks.Queries
{
    public record GetTaskByIdQuery(Guid Id) : IRequest<Response<TaskItem>>;
    
}
