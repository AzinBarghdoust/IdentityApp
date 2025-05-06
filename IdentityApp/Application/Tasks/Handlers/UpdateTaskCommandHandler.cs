using IdentityApp.Application.Tasks.Commands;
using IdentityApp.Persistence.Contexts;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using IdentityApp.Application.Common.Responses;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Response<Guid>>
    {
        private readonly SqlServerContext _context;

        public UpdateTaskCommandHandler(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(request.Id);

            if (task == null)
                return new Response<Guid>("Task not found", false);

            task.Title = request.Title;
            task.Description = request.Description;
            task.Status = (Domain.Entities.TasksStatus)request.Status;

            await _context.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(task.Id, "Task updated successfully");
        }
    }
}
