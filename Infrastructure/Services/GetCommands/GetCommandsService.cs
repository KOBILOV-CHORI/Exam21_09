using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Npgsql;

namespace Infrastructure.Services.GetCommands;

public class GetCommandsService : IGetCommandsService
{
    public async Task<IEnumerable<Domain.Models.UserWithTasks>> GetUserWithTasksAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                var users = await connection.QueryAsync<Domain.Models.User>(SqlCommands.GetAllUsers);
                var usersWithTasks = new List<Domain.Models.UserWithTasks>();
                foreach (var user in users)
                {
                    UserWithTasks userWithTasks = new UserWithTasks();
                    userWithTasks.Id = user.Id;
                    userWithTasks.UserName = user.UserName;
                    userWithTasks.Email = user.Email;
                    userWithTasks.PasswordHash = user.PasswordHash;
                    userWithTasks.CreatedAt = user.CreatedAt;
                    userWithTasks.Tasks =
                        await connection.QueryAsync<Domain.Models.Task>(SqlCommands.GetAllTasksByUserId,
                            new { userid = user.Id });
                    usersWithTasks.Add(userWithTasks);
                }

                return usersWithTasks;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<CategoryWithCountTasks>> GetCategoriesWithCountTasks()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                var categories = await connection.QueryAsync<Domain.Models.Category>(SqlCommands.GetAllCategories);
                var categoryWithCountTasksList = new List<Domain.Models.CategoryWithCountTasks>();
                foreach (var category in categories)
                {
                    CategoryWithCountTasks categoryWithCountTasks = new CategoryWithCountTasks();
                    categoryWithCountTasks.Id = category.Id;
                    categoryWithCountTasks.Name = category.Name;
                    categoryWithCountTasks.CreatedAt = category.CreatedAt;
                    categoryWithCountTasks.CountTasks =  await connection.QuerySingleAsync<int>(
                        SqlCommands.GetCountTasks,
                        new { categoryid = category.Id }
                    );                    
                    categoryWithCountTasksList.Add(categoryWithCountTasks);
                }

                return categoryWithCountTasksList;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.TaskWithUserAndCategory>> GetTasksFullInfo()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.TaskWithUserAndCategory>(SqlCommands.GetTasksWithUserAndCategory);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Task>> GetTasksByOrder()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Task>(SqlCommands.GetTaskByOrder);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Domain.Models.Task>> GetHistoriesOfTask(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Task>(SqlCommands.GetHistoriesOfTasks, new{taskid = id});
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}