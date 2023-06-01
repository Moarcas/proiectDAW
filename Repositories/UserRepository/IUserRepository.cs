using proiectDAW.Models;

namespace proiectDAW.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<bool> SaveChanges();
        User GetByEmail(string email);
        bool EmailExists(string email);
    }
}