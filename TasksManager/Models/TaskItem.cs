using System.ComponentModel.DataAnnotations;

namespace TasksManager.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Display(Name = "Data de Vencimento"), DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Pendente,
        EmProgresso,
        Concluida
    }
}
