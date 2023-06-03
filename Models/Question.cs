using proiectDAW.Models.DTO;

namespace proiectDAW.Models {
    public class Question {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; }
        public UserDto? user { get; set; }
    }
}