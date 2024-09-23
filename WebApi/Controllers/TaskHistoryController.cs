using Domain.Models;
using Infrastructure.Services.TaskHistory;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("TaskHistory")]
[ApiController]
public class TaskHistoryController : ControllerBase
{
    private readonly ITaskHistoryService _taskHistoryService;

    public TaskHistoryController(ITaskHistoryService taskHistoryService)
    {
        _taskHistoryService = taskHistoryService;
    }
    [HttpPost("TaskHistory")]
    public async Task<bool> AddTaskHistory(TaskHistory taskHistory)
    {
        var result = await _taskHistoryService.AddTaskHistoryAsync(taskHistory);
        return result;
    }
    [HttpPut("TaskHistory")]
    public async Task<bool> UpdateTaskHistory(TaskHistory taskHistory)
    {
        var result = await _taskHistoryService.UpdateTaskHistoryAsync(taskHistory);
        return result;
    }
    [HttpDelete("TaskHistory")]
    public async Task<bool> DeleteTaskHistory(Guid id)
    {
        var result = await _taskHistoryService.DeleteTaskHistoryAsync(id);
        return result;
    }
    [HttpGet("TaskHistory")]
    public async Task<TaskHistory> GetTaskHistoryById(Guid id)
    {
        var result = await _taskHistoryService.GetTaskHistoryByIdAsync(id);
        return result;
    }
    [HttpGet("GetTaskHistories")]
    public async Task<IEnumerable<TaskHistory>> GetCategories()
    {
        var result = await _taskHistoryService.GetTaskHistoriesAsync();
        return result;
    }
}