namespace Domain.Models;

public class UserWithTasks
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Task> Tasks { get; set; }
}