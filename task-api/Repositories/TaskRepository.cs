using task_api.Migrations;
using TaskModel = task_api.Models.Task;

namespace task_api.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public TaskModel CreateTask(TaskModel newTask)
    {
        _context.Task.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }

    public void DeleteTaskById(int taskId)
    {
        var task = _context.Task.Find(taskId);
        if (task != null) {
            _context.Task.Remove(task); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<TaskModel> GetAllTasks()
    {
        return _context.Task.ToList();
    }

    public TaskModel? UpdateTask(TaskModel newTask)
    {
        var originalTask = _context.Task.Find(newTask.TaskId);
        if (originalTask != null) {
            originalTask.Title = newTask.Title;
            originalTask.Completed = newTask.Completed;
            _context.SaveChanges();
        }
        return originalTask;
    }
}