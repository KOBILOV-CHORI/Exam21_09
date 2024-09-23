using Domain.Enums;

namespace Domain.Models;

public class TaskWithUserAndCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime UserCreatedAt { get; set; }
    public string CategoryName { get; set; }
    public DateTime CategoryCreatedAt { get; set; }
}