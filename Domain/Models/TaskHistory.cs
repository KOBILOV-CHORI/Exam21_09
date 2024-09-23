namespace Domain.Models;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string ChangeDescription { get; set; }
    public DateTime CreatedAt { get; set; }
}