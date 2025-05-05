using Microsoft.AspNetCore.Mvc;
using TasksManager.Models;
using TasksManager.Repositories;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Ação para obter todas as tarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> Get()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        // Ação para criar uma nova tarefa
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TaskItem task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            await _taskRepository.CreateTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        // Ação para atualizar uma tarefa existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TaskItem task)
        {
            if (task == null || task.Id != id)
            {
                return BadRequest();
            }

            await _taskRepository.UpdateTask(task);
            return NoContent();
        }

        // Ação para deletar uma tarefa existente
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskRepository.DeleteTask(id);
            return NoContent();
        }

        // Ação para obter tarefas filtradas (status ou data de vencimento)
        [HttpGet("filtered")]  // Mudamos a rota para tornar única
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetFiltered(
            [FromQuery] string? status,
            [FromQuery] DateTime? dueDate)
        {
            var tasks = await _taskRepository.GetFiltered(status, dueDate);
            return Ok(tasks);
        }
    }
}
