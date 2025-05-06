using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityApp.Application.Common.Responses;
using IdentityApp.Application.Tasks.Commands;
using IdentityApp.Persistence.Contexts;
using MediatR;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Response<Guid>>
    {
        private readonly SqlServerContext _context;

        public DeleteTaskCommandHandler(    SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);

            if (task == null)
                return new Response<Guid>("Task not found", false);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(request.Id, "Task deleted successfully");
        }
    }
}
