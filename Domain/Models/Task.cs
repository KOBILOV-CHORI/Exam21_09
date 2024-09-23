using Domain.Enums;

namespace Domain.Models;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
}