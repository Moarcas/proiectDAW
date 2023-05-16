using proiectDAW.Models;

namespace proiectDAW.Services.UserService
{
    public interface IUserService
    {
        Task Create(User user);
    }
}