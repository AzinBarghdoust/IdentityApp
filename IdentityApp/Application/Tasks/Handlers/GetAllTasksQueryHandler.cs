using IdentityApp.Application.Common.Responses;
using IdentityApp.Application.Tasks.Queries;
using IdentityApp.Domain.Entities;
using IdentityApp.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Domain.Repositories;

namespace IdentityApp.Application.Tasks.Handlers
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, Response<List<TaskItem>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly SqlServerContext _context;

        public GetAllTasksQueryHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public async Task<Response<List<TaskItem>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.GetAllAsync();
            var response = new Response<List<TaskItem>>
            {
                Data = task.ToList(),
                Message = "Tasks fetched successfully",
                Success = true
            };
            return response;

        }
    }
    
}
