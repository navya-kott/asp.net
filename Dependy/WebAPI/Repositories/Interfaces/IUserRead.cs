using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserRead
    {
        Task<List<User>?> GetUsersAsync();

        Task<User?> GetUserByIdAsync(string id);

        Task<User?> GetUserByNameAsync(string name);
    }
}
