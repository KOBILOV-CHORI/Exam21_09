using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Infrastructure.Services.TaskAttachment;
using Npgsql;

namespace Infrastructure.Services.Task;

public class TaskAttachmentService : ITaskAttachmentService
{
    public async Task<IEnumerable<Domain.Models.TaskAttachment>> GetTaskAttachmentsAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.TaskAttachment>(SqlCommands.GetAllTaskAttachments);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Domain.Models.TaskAttachment>? GetTaskAttachmentByIdAsync(Guid id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Domain.Models.TaskAttachment>(SqlCommands.GetTaskAttachmentById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> AddTaskAttachmentAsync(Domain.Models.TaskAttachment task)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.AddTaskAttachment, task) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskAttachmentAsync(Domain.Models.TaskAttachment task)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.UpdateTaskAttachment, task) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskAttachmentAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.DeleteTaskAttachment, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}