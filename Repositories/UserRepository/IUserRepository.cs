using proiectDAW.Models;

namespace proiectDAW.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        User GetByEmail(string email);
        User GetById(Guid id);
        bool EmailExists(string email);
        Task<bool> SaveChanges();
    }
}