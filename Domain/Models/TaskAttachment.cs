namespace Domain.Models;

public class TaskAttachment
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string FilePath { get; set; }
    public DateTime CreatedAt { get; set; }
}