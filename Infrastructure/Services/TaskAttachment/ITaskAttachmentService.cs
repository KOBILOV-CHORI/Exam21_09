namespace Infrastructure.Services.TaskAttachment;

public interface ITaskAttachmentService
{
    Task<IEnumerable<Domain.Models.TaskAttachment>> GetTaskAttachmentsAsync();
    Task<bool> DeleteTaskAttachmentAsync(Guid id);
    Task<bool> UpdateTaskAttachmentAsync(Domain.Models.TaskAttachment task);
    Task<bool> AddTaskAttachmentAsync(Domain.Models.TaskAttachment task);
    Task<Domain.Models.TaskAttachment>? GetTaskAttachmentByIdAsync(Guid id);
}