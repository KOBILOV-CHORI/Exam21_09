using Dapper;
using Domain.Models;
using Infrastructure.Commands;
using Npgsql;

namespace Infrastructure.Services.Category;

public class CategoryService : ICategoryService
{
    public async Task<IEnumerable<Domain.Models.Category>> GetCategoriesAsync()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Domain.Models.Category>(SqlCommands.GetAllCategories);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<Domain.Models.Category>? GetCategoryByIdAsync(Guid id)
    {
        try
        {
            using ( NpgsqlConnection conn = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Domain.Models.Category>(SqlCommands.GetCategoryById, new { Id = id });
            }
            
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> AddCategoryAsync(Domain.Models.Category category)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.AddCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateCategoryAsync(Domain.Models.Category category)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.UpdateCategory, category) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection connection= new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommands.DeleteCategory, new {Id=id}) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}