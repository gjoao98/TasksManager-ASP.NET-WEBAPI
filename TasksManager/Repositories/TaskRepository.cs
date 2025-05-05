using Microsoft.EntityFrameworkCore;
using TasksManager.Database;
using TasksManager.Models;

namespace TasksManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetFiltered(string? status, DateTime? dueDate)
        {
            var query = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<Models.TaskStatus>(status, true, out var parsedStatus))
                {
                    query = query.Where(t => t.Status == parsedStatus);
                }
                else
                {
                    return Enumerable.Empty<TaskItem>(); // ou lançar exceção, dependendo da sua escolha
                }
            }

            if (dueDate != null)
            {
                query = query.Where(t => t.DueDate.Date == dueDate.Value.Date); // Compara sem o horário.
            }

            return await query.ToListAsync();
        }
    }
}
