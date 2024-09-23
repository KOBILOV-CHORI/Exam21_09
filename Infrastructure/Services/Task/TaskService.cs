using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Npgsql;

namespace Infrastructure.Services.Task;

public class TaskService : ITaskService
{
    public async Task<IEnumerable<Domain.Models.Task>> GetTasksAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Task>(SqlCommands.GetAllTasks);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Domain.Models.Task>? GetTaskByIdAsync(Guid id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Domain.Models.Task>(SqlCommands.GetTaskById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> AddTaskAsync(Domain.Models.Task task)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.AddTask, task) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskAsync(Domain.Models.Task task)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.UpdateTask, task) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.DeleteTask, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}