using proiectDAW.Models;

namespace proiectDAW.Repositories.QuestionRepository {
    public interface IQuestionRepository {
        Task<Question?> GetById(Guid id);
        Task<List<Question>> GetAll();
        Task<List<Question>> GetByUserId(Guid userId);
        Task Add(Question question);
        Task Update(Question question);
        Task Delete(Guid id);
        Task<bool> SaveChanges();
    }
}