using System.Net;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

using QuickTaskAPI.Business.Features.Task;
using QuickTaskAPI.Business.Features.Task.Request.v1;
using QuickTaskAPI.Business.Features.Task.Response.v1;


namespace QuickTaskAPI.Controllers
{

    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TasksController(ITaskService taskService, ILogger<TasksController> logger) : ControllerBase
    {

        /// <summary>
        /// Retrieves a list of tasks with pagination.
        /// </summary>
        /// <param name="page">Page number (default is 1).</param>
        /// <param name="pageSize">Page size (default is 10).</param>
        /// <returns>List of tasks.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TaskResponseViewModel>), 200)]
        public async Task<ActionResult<IEnumerable<TaskResponseViewModel>>> GetAllAsync(
            [FromQuery(Name = "page")] [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0.")]
        int page = 1,
            [FromQuery(Name = "pageSize")] [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        int pageSize = 10)
        {
            return Ok(await taskService.GetAllAsync(page,pageSize));
        }


        /// <summary>
        /// Retrieves a specific task by ID.
        /// </summary>
        /// <param name="id">Task ID.</param>
        /// <returns>Task details.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TaskResponseViewModel), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TaskResponseViewModel>> GetTaskByIdAsync(Guid id)
        {
            var task = await taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="taskViewModel">Task data.</param>
        /// <returns>Newly created task details.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskResponseViewModel), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTaskAsync([FromBody] TaskRequestViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTask = await taskService.AddAsync(taskViewModel);
            return new ObjectResult(new
            {
                id = newTask.Id,
                resource = $"api/v1/tasks/{newTask.Id}"
            }){ StatusCode = (int)HttpStatusCode.Created };
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="id">Task ID.</param>
        /// <param name="taskViewModel">Updated task data.</param>
        /// <returns>Updated task details.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskRequestViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateTaskAsync(Guid id, [FromBody] TaskRequestViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await taskService.UpdateAsync(id,taskViewModel);

            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">Task ID.</param>
        /// <returns>No content if successful, otherwise not found.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteTaskAsync(Guid id)
        {
            var success = await taskService.DeleteAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
