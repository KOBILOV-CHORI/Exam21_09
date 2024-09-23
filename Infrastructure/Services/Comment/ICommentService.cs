namespace Infrastructure.Services.Comment;

public interface ICommentService
{
        
    Task<IEnumerable<Domain.Models.Comment>> GetCommentsAsync();
    Task<bool> DeleteCommentAsync(Guid id);
    Task<bool> UpdateCommentAsync(Domain.Models.Comment comment);
    Task<bool> AddCommentAsync(Domain.Models.Comment comment);
    Task<Domain.Models.Comment>? GetCommentByIdAsync(Guid id);
}