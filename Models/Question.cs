namespace proiectDAW.Models {
    public class Question {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; }

        public User user { get; set; }
    }
}