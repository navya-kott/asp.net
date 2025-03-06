namespace WebAPI.Repositories.Interfaces
{
    public interface IUserUpdate
    {
        Task<bool> UpdateUserByIdAsync(string id);
    }
}
