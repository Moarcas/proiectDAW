
namespace proiectDAW.Models.DTO.UserAuthDto {
    public class UserAuthDto {
        public Guid id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string jwtToken { get; set; }

        public UserAuthDto(User user, string jwtToken_) {
            id = user.id;
            email = user.email;
            username = user.username;
            jwtToken = jwtToken_;
        }
    }
}