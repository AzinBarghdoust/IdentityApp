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

namespace IdentityApp.Application.Tasks.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Response<Guid>>
    {
        //private readonly ITaskRepository _taskRepository;
        private readonly SqlServerContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateTaskCommandHandler( SqlServerContext context,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
           // _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response<Guid>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = TasksStatus.Pending,
                UserId = userId,
                 
            };
             _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(task.Id, "Task created successfully");
        }
    }
}
