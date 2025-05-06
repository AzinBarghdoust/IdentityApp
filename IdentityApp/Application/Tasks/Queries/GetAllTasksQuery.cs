using System.Collections.Generic;
using IdentityApp.Application.Common.Responses;
using IdentityApp.Domain.Entities;
using MediatR;

namespace IdentityApp.Application.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<Response<List<TaskItem>>>
    {
    }
}
