using Domain.Models;
using Infrastructure.Services.Comment;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("Comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    [HttpPost("Comment")]
    public async Task<bool> AddComment(Comment comment)
    {
        var result = await _commentService.AddCommentAsync(comment);
        return result;
    }
    [HttpPut("Comment")]
    public async Task<bool> UpdateComment(Comment comment)
    {
        var result = await _commentService.UpdateCommentAsync(comment);
        return result;
    }
    [HttpDelete("Comment")]
    public async Task<bool> DeleteComment(Guid id)
    {
        var result = await _commentService.DeleteCommentAsync(id);
        return result;
    }
    [HttpGet("Comment")]
    public async Task<Comment> GetCommentById(Guid id)
    {
        var result = await _commentService.GetCommentByIdAsync(id);
        return result;
    }
    [HttpGet("GetComments")]
    public async Task<IEnumerable<Comment>> GetCategories()
    {
        var result = await _commentService.GetCommentsAsync();
        return result;
    }
}