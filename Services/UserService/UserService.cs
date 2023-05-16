using proiectDAW.Models;
using proiectDAW.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiectDAW.Services.UserService {
    public class UserService : IUserService {
        public IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task Create(User user) {
            var newUser = new User {
                id = user.id,
                email = user.email,
                password = BCryptNet.HashPassword(user.password),
                username = user.username
            };

            await _userRepository.Create(newUser);
            await _userRepository.SaveChanges();
        }
    }
}