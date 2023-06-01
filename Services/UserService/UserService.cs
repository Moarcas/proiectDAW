using proiectDAW.Helpers.Jwt;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Models.DTO.UserAuthDto;
using proiectDAW.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiectDAW.Services.UserService {
    public class UserService : IUserService {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;
        
        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils) {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public ResponseDto<UserAuthDto> Create(User user) {
            var newUser = new User {
                id = user.id,
                email = user.email,
                password = BCryptNet.HashPassword(user.password),
                username = user.username
            };

            _userRepository.Create(newUser);
            _userRepository.SaveChanges();

            // Generate jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(newUser);

            return new ResponseDto<UserAuthDto>(new UserAuthDto(newUser, jwtToken));
        }

        public ResponseDto<UserAuthDto> Authenticate(LoginDto loginDto) { 
            var userFromDb = _userRepository.GetByEmail(loginDto.email);

            if (userFromDb == null || !BCryptNet.Verify(loginDto.password, userFromDb.password)) {
                return new ResponseDto<UserAuthDto>(null, false, "Email or password is incorrect", 400);
            }

            // Generate jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(userFromDb);

            return new ResponseDto<UserAuthDto>(new UserAuthDto(userFromDb, jwtToken));         
        }

        public bool IsEmailAlreadyUsed(string email) {
            return _userRepository.EmailExists(email);
        }
    }
}