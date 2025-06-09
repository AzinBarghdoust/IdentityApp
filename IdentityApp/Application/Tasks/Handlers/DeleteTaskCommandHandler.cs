using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityApp.Application.Common.Responses;
using IdentityApp.Application.Tasks.Commands;
using IdentityApp.Persistence.Contexts;
using MediatR;
using TaskManagement.Domain.Repositories;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(request.Id);

            if (task == null)
                return new Response<Guid>("Task not found", false);

            _unitOfWork.Tasks.DeleteAsync(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(request.Id, "Task deleted successfully");
        }
    }
}
