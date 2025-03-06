using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserDelete
    {

        Task<bool> DeleteUserAsync(User user);

    }
}
