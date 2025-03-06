using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserCreate
    {

        Task CreateUserAsync(User user); 
 
    }
}
