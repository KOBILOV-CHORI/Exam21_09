using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Npgsql;

namespace Infrastructure.Services.Comment;

public class CommentService : ICommentService
{
    public async Task<IEnumerable<Domain.Models.Comment>> GetCommentsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Comment>(SqlCommands.GetAllComments);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Domain.Models.Comment>? GetCommentByIdAsync(Guid id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Domain.Models.Comment>(SqlCommands.GetCommentById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> AddCommentAsync(Domain.Models.Comment comment)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.AddComment, comment) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCommentAsync(Domain.Models.Comment comment)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.UpdateComment, comment) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCommentAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.DeleteComment, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}