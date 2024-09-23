namespace Infrastructure.Services.User;

public interface IUserService
{
    Task<IEnumerable<Domain.Models.User>> GetUsersAsync();
    Task<bool> DeleteUserAsync(Guid id);
    Task<bool> UpdateUserAsync(Domain.Models.User user);
    Task<bool> AddUserAsync(Domain.Models.User user);
    Task<Domain.Models.User>? GetUserByIdAsync(Guid id);
}