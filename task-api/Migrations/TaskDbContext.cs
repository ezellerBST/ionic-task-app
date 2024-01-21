using Microsoft.EntityFrameworkCore;
using TaskModel = task_api.Models.Task;

namespace task_api.Migrations;

public class TaskDbContext : DbContext
{
    public DbSet<TaskModel> Task { get; set; }
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskModel>(entity =>
        {
            entity.HasKey(e => e.TaskId);
            entity.Property(e => e.Title);
            entity.Property(e => e.Completed);
        });
    }
}