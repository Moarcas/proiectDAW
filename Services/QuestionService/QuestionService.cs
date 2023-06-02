using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Repositories.QuestionRepository;

namespace proiectDAW.Services.QuestionService {
    public class QuestionService : IQuestionService {
        public IQuestionRepository _questionRepository;
       
        public QuestionService(IQuestionRepository questionRepository) {
            _questionRepository = questionRepository;
        }

        public async Task<ResponseDto<Question>> GetById(Guid id) {
            var question = await _questionRepository.GetById(id);

            if (question == null) {
                return new ResponseDto<Question>(null, false, "Question not found");
            }
            return new ResponseDto<Question>(question);
        }

        public async Task<ResponseDto<List<Question>>> GetAll() {   
            List<Question> questions = await _questionRepository.GetAll();
            return new ResponseDto<List<Question>>(questions);
        }

        public async Task<ResponseDto<List<Question>>> GetByUserId(Guid userId) {
            List<Question> questions = await _questionRepository.GetByUserId(userId);
            return new ResponseDto<List<Question>>(questions);
        }

        public async Task<ResponseDto<Question>> AddQuestion(Question question) {
            question.createdAt = DateTime.Now;
            await _questionRepository.Add(question);
            await _questionRepository.SaveChanges();
            return new ResponseDto<Question>(question);
        }

        public async Task<ResponseDto<Question>> UpdateQuestion(Question question) {
            await _questionRepository.Update(question);
            await _questionRepository.SaveChanges();
            return new ResponseDto<Question>(question);
        }

        public async Task<ResponseDto<Question>> DeleteQuestion(Guid id) {
            await _questionRepository.Delete(id);
            await _questionRepository.SaveChanges();
            return new ResponseDto<Question>(null);
        }

        public Task<ResponseDto<Question>> UpdateQuestion(Guid id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}