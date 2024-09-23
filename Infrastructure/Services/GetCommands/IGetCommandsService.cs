using Domain.Models;

namespace Infrastructure.Services.GetCommands;

public interface IGetCommandsService
{
    Task<IEnumerable<Domain.Models.UserWithTasks>> GetUserWithTasksAsync();
    Task<IEnumerable<CategoryWithCountTasks>> GetCategoriesWithCountTasks();
    Task<IEnumerable<Domain.Models.TaskWithUserAndCategory>> GetTasksFullInfo();
    Task<IEnumerable<Domain.Models.Task>> GetTasksByOrder();
    Task<IEnumerable<Domain.Models.Task>> GetHistoriesOfTask(Guid id);
    
}