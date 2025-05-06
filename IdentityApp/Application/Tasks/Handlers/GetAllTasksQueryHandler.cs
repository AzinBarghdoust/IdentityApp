using IdentityApp.Application.Common.Responses;
using IdentityApp.Application.Tasks.Queries;
using IdentityApp.Domain.Entities;
using IdentityApp.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Response<List<TaskItem>>>
    {
        private readonly SqlServerContext _context;

        public GetAllTasksQueryHandler( SqlServerContext context)
        {
            _context = context;
            
        }
        public async Task<Response<List<TaskItem>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.ToListAsync(cancellationToken);
            var response = new Response<List<TaskItem>>
            {
                Data = task,
                Message = "Tasks fetched successfully",
                Success = true
            };
            return response;

        }
    }
    
}
