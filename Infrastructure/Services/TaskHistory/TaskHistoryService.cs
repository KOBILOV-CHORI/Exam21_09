using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Npgsql;

namespace Infrastructure.Services.TaskHistory;

public class TaskHistoryService : ITaskHistoryService
{
    public async Task<IEnumerable<Domain.Models.TaskHistory>> GetTaskHistoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.TaskHistory>(SqlCommands.GetAllTaskHistories);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Domain.Models.TaskHistory>? GetTaskHistoryByIdAsync(Guid id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Domain.Models.TaskHistory>(SqlCommands.GetTaskHistoryById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> AddTaskHistoryAsync(Domain.Models.TaskHistory taskhistory)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.AddTaskHistory, taskhistory) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskHistoryAsync(Domain.Models.TaskHistory taskhistory)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.UpdateTaskHistory, taskhistory) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskHistoryAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.DeleteTaskHistory, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}