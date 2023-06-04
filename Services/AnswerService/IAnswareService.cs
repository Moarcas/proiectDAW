using proiectDAW.Models;
using proiectDAW.Models.DTO;

namespace proiectDAW.Services.AnswerService {
    public interface IAnswerService {
        Task<ResponseDto<List<Answer>>> GetByQuestionId(Guid questionId);
        Task<ResponseDto<Answer>> AddAnswer(Answer answer);
        Task<ResponseDto<Answer>> UpdateAnswer(Answer answer);
        Task<ResponseDto<Answer>> DeleteAnswer(Guid id);
    }
}