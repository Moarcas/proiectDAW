using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Models.DTO.UserAuthDto;

namespace proiectDAW.Services.UserService
{
    public interface IUserService
    {
        ResponseDto<UserAuthDto> Create(User user);
        ResponseDto<UserAuthDto> Authenticate(LoginDto loginDto);
        bool IsEmailAlreadyUsed(string email);
    }
}