namespace Infrastructure.Services.TaskHistory;

public interface ITaskHistoryService
{
    Task<IEnumerable<Domain.Models.TaskHistory>> GetTaskHistoriesAsync();
    Task<bool> DeleteTaskHistoryAsync(Guid id);
    Task<bool> UpdateTaskHistoryAsync(Domain.Models.TaskHistory taskhistory);
    Task<bool> AddTaskHistoryAsync(Domain.Models.TaskHistory taskhistory);
    Task<Domain.Models.TaskHistory>? GetTaskHistoryByIdAsync(Guid id);
}