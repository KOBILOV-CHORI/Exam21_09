using Domain.Models;
using Infrastructure.Services.TaskAttachment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("TaskAttachment")]
[ApiController]
public class TaskAttachmentController : ControllerBase
{
    private readonly ITaskAttachmentService _taskAttachmentService;

    public TaskAttachmentController(ITaskAttachmentService taskAttachmentService)
    {
        _taskAttachmentService = taskAttachmentService;
    }
    [HttpPost("TaskAttachment")]
    public async Task<bool> AddTaskAttachment(TaskAttachment taskAttachment)
    {
        var result = await _taskAttachmentService.AddTaskAttachmentAsync(taskAttachment);
        return result;
    }
    [HttpPut("TaskAttachment")]
    public async Task<bool> UpdateTaskAttachment(TaskAttachment taskAttachment)
    {
        var result = await _taskAttachmentService.UpdateTaskAttachmentAsync(taskAttachment);
        return result;
    }
    [HttpDelete("TaskAttachment")]
    public async Task<bool> DeleteTaskAttachment(Guid id)
    {
        var result = await _taskAttachmentService.DeleteTaskAttachmentAsync(id);
        return result;
    }
    [HttpGet("TaskAttachment")]
    public async Task<TaskAttachment> GetTaskAttachmentById(Guid id)
    {
        var result = await _taskAttachmentService.GetTaskAttachmentByIdAsync(id);
        return result;
    }
    [HttpGet("GetTaskAttachments")]
    public async Task<IEnumerable<TaskAttachment>> GetCategories()
    {
        var result = await _taskAttachmentService.GetTaskAttachmentsAsync();
        return result;
    }
}