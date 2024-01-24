using ReceptDatabas.Entities;

namespace ReceptDatabas.Interface
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
