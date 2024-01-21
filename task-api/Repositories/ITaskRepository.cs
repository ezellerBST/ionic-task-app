using TaskModel = task_api.Models.Task;


namespace task_api.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskModel> GetAllTasks();
    TaskModel CreateTask(TaskModel newTask);
    TaskModel? UpdateTask(TaskModel newTask);
    void DeleteTaskById(int taskId);

}