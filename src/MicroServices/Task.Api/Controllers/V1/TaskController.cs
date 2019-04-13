using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Task.Api.Application.Model;

namespace Task.Api.Controllers.V1
{
    /// <summary>Task Controller</summary>
    public class TaskController : Controller
    {
        private readonly IMediator mediator;

        /// <summary>Initializes a new instance of the <see cref="TaskController"/> class.</summary>
        /// <param name="mediatior">The mediatior.</param>
        public TaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>Creates the task.</summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var taskID = await this.mediator.Send(command);

            return Ok(taskID);
        }
    }
}
