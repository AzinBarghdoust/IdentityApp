using IdentityApp.Application.Tasks.Commands;
using IdentityApp.Persistence.Contexts;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using IdentityApp.Domain.Entities;
using IdentityApp.Application.Common.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityApp.Domain.Repositories;
using TaskManagement.Domain.Repositories;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = TasksStatus.Pending,
                UserId = userId,
            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(task.Id, "Task created successfully");
        }
    }
}
