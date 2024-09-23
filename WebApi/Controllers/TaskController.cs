using Domain.Models;
using Infrastructure.Services.Task;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Models.Task;

namespace WebApi.Controllers;

[Route("Task")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpPost("Task")]
    public async Task<bool> AddTask(Task task)
    {
        var result = await _taskService.AddTaskAsync(task);
        return result;
    }
    [HttpPut("Task")]
    public async Task<bool> UpdateTask(Task task)
    {
        var result = await _taskService.UpdateTaskAsync(task);
        return result;
    }
    [HttpDelete("Task")]
    public async Task<bool> DeleteTask(Guid id)
    {
        var result = await _taskService.DeleteTaskAsync(id);
        return result;
    }
    [HttpGet("Task")]
    public async Task<Task> GetTaskById(Guid id)
    {
        var result = await _taskService.GetTaskByIdAsync(id);
        return result;
    }
    [HttpGet("GetTasks")]
    public async Task<IEnumerable<Task>> GetCategories()
    {
        var result = await _taskService.GetTasksAsync();
        return result;
    }
}