using System.Threading;
using System.Threading.Tasks;
using IdentityApp.Application.Common.Responses;
using IdentityApp.Application.Tasks.Queries;
using IdentityApp.Domain.Entities;
using IdentityApp.Persistence.Contexts;
using MediatR;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Response<TaskItem>>
    {
        private readonly SqlServerContext _context;
        public GetTaskByIdQueryHandler(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<Response<TaskItem>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);
            if (task == null)
            {
                return new Response<TaskItem>("Task not found", false);
            }
            return new Response<TaskItem>(task, "Task retrieved");
        }
    }
}
