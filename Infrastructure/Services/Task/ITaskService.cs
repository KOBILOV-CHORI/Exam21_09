namespace Infrastructure.Services.Task;

public interface ITaskService
{
    Task<IEnumerable<Domain.Models.Task>> GetTasksAsync();
    Task<bool> DeleteTaskAsync(Guid id);
    Task<bool> UpdateTaskAsync(Domain.Models.Task task);
    Task<bool> AddTaskAsync(Domain.Models.Task task);
    Task<Domain.Models.Task>? GetTaskByIdAsync(Guid id);
}