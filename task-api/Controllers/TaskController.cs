using TaskModel = task_api.Models.Task;
using task_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace task_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskRepository _taskRepository;

        public TaskController(ILogger<TaskController> logger, ITaskRepository repository)
        {
            _logger = logger;
            _taskRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetTasks()
        {
            return Ok(_taskRepository.GetAllTasks());
        }

        [HttpPost]
        public ActionResult<TaskModel> CreateTask(TaskModel task)
        {
            if (!ModelState.IsValid || task == null)
            {
                return BadRequest();
            }
            var newTask = _taskRepository.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut]
        [Route("{taskId:int}")]
        public ActionResult<TaskModel> UpdateTask(int taskId, TaskModel task)
        {
            if (!ModelState.IsValid || taskId != task.TaskId)
            {
                return BadRequest();
            }
            return Ok(_taskRepository.UpdateTask(task));
        }

        [HttpDelete]
        [Route("{taskId:int}")]
        public ActionResult DeleteTask(int taskId)
        {
            _taskRepository.DeleteTaskById(taskId);
            return NoContent();
        }
    }

}
