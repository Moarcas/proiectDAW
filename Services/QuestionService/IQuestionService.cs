using proiectDAW.Models;
using proiectDAW.Models.DTO;

namespace proiectDAW.Services.QuestionService {
    public interface IQuestionService {
        Task<ResponseDto<Question>> GetById(Guid id);
        Task<ResponseDto<List<Question>>> GetAll();
        Task<ResponseDto<List<Question>>> GetByUserId(Guid userId);
        Task<ResponseDto<Question>> AddQuestion(Question question);
        Task<ResponseDto<Question>> UpdateQuestion(Question question);
        Task<ResponseDto<Question>> DeleteQuestion(Guid id);
    }
}   