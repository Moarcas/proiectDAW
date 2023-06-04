using proiectDAW.Models;

namespace proiectDAW.Repositories.AnswerRepository {
    public interface IAnswerRepository {
        Task<List<Answer>> GetByQuestionId(Guid questionId);
        Task<Answer?> GetById(Guid id);
        Task Add(Answer answer);
        Task Update(Answer answer);
        Task Delete(Guid id);
        Task<bool> SaveChanges();
    }
}