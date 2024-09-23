using Domain.Models;
using Infrastructure.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("User")]
    public async Task<bool> AddUser(User user)
    {
        var result = await _userService.AddUserAsync(user);
        return result;
    }
    [HttpPut("User")]
    public async Task<bool> UpdateUser(User user)
    {
        var result = await _userService.UpdateUserAsync(user);
        return result;
    }
    [HttpDelete("User")]
    public async Task<bool> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUserAsync(id);
        return result;
    }
    [HttpGet("User")]
    public async Task<User> GetUserById(Guid id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        return result;
    }
    [HttpGet("GetUsers")]
    public async Task<IEnumerable<User>> GetCategories()
    {
        var result = await _userService.GetUsersAsync();
        return result;
    }
}