namespace Domain.Models;

public class CategoryWithCountTasks
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CountTasks { get; set; }
}