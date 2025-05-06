using System;
using System.Threading.Tasks;
using IdentityApp.Application.Tasks.Commands;
using IdentityApp.Application.Tasks.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("Create-Task")]
        public async Task<IActionResult> CreateTask(CreateTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
        [Authorize]
        [HttpGet("Taskslist")]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));
            return Ok(result);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var result = await _mediator.Send(new DeleteTaskCommand(id));
            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
