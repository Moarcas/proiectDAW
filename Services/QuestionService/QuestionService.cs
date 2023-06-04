using AutoMapper;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Repositories.QuestionRepository;
using proiectDAW.Repositories.UserRepository;

namespace proiectDAW.Services.QuestionService {
    public class QuestionService : IQuestionService {
        public IQuestionRepository _questionRepository;
        public IUserRepository _userRepository;
        public IMapper _mapper;
       
        public QuestionService(IQuestionRepository questionRepository, IUserRepository userRepository, IMapper mapper) {
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
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

            for (int i = 0; i < questions.Count; i++) {
                User user = _userRepository.GetById(questions[i].userId);
                questions[i].user = user;
            }
    
            return new ResponseDto<List<Question>>(questions);
        }

        public async Task<ResponseDto<List<Question>>> GetByUserId(Guid userId) {
            List<Question> questions = await _questionRepository.GetByUserId(userId);
            return new ResponseDto<List<Question>>(questions);
        }

        public async Task<ResponseDto<Question>> AddQuestion(Question question) {
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
    }
}