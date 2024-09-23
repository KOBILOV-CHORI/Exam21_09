namespace Domain.Models;

public class Comment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid TaskId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}