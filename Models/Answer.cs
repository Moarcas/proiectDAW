using proiectDAW.Models.DTO;

namespace proiectDAW.Models {
    public class Answer {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public Guid questionId { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; }
        public User? user { get; set; }
        public Question? question { get; set; }
    }
}