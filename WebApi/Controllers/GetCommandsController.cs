using Domain.Models;
using Infrastructure.Services.GetCommands;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("Commands")]
[ApiController]
public class GetCommandsController : ControllerBase
{
    private readonly IGetCommandsService _getCommandsService;

    public GetCommandsController(IGetCommandsService getCommandsService)
    {
        _getCommandsService = getCommandsService;
    }

    [HttpGet("GetUsersWithTasks")]
    public async Task<IEnumerable<UserWithTasks>> GetUsersWithTasks()
    {
        var result = await _getCommandsService.GetUserWithTasksAsync();
        return result;
    }
    [HttpGet("GetCategoriesWithCountTasks")]
    public async Task<IEnumerable<CategoryWithCountTasks>> GetCategoriesWithCountTasks()
    {
        var result = await _getCommandsService.GetCategoriesWithCountTasks();
        return result;
    }
    [HttpGet("GetTasksFullInfo")]
    public async Task<IEnumerable<TaskWithUserAndCategory>> GetTasksFullInfo()
    {
        var result = await _getCommandsService.GetTasksFullInfo();
        return result;
    }
    [HttpGet("GetTasksByOrder")]
    public async Task<IEnumerable<Domain.Models.Task>> GetTasksByOrder()
    {
        var result = await _getCommandsService.GetTasksByOrder();
        return result;
    }
    [HttpGet("GetHistoriesOfTask")]
    public async Task<IEnumerable<Domain.Models.Task>> GetHistoriesOfTask(Guid id)
    {
        var result = await _getCommandsService.GetHistoriesOfTask(id);
        return result;
    }
}