using TasksManager.Models;

namespace TasksManager.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllTasks();
        Task CreateTask(TaskItem task);
        Task UpdateTask(TaskItem task);
        Task DeleteTask(int id);
        Task<IEnumerable<TaskItem>> GetFiltered(string? status, DateTime? dueDate);
    }
}
