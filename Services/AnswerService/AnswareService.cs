using AutoMapper;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Repositories.AnswerRepository;
using proiectDAW.Repositories.QuestionRepository;
using proiectDAW.Repositories.UserRepository;

namespace proiectDAW.Services.AnswerService {
    public class AnswerService : IAnswerService {
        public IAnswerRepository _answerRepository;
        public IUserRepository _userRepository;
        public IQuestionRepository _questionRepository;
        public IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IUserRepository userRepository, IQuestionRepository questionRepository, IMapper mapper) {
            _answerRepository = answerRepository;
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<Answer>>> GetByQuestionId(Guid questionId) {
            List <Answer> answers = new List<Answer>();

            answers = await _answerRepository.GetByQuestionId(questionId);

            for (int i = 0; i < answers.Count; i++) {
                User user = _userRepository.GetById(answers[i].userId);
                Question question = await _questionRepository.GetById(answers[i].questionId);
                answers[i].user = user;
                answers[i].question = question;
            }
            return new ResponseDto<List<Answer>>(answers);
        }

        public async Task<ResponseDto<Answer>> AddAnswer(Answer answer) {
            await _answerRepository.Add(answer);
            await _answerRepository.SaveChanges();
            return new ResponseDto<Answer>(answer);
        }

        public async Task<ResponseDto<Answer>> UpdateAnswer(Answer answer) {
            await _answerRepository.Update(answer);
            await _answerRepository.SaveChanges();
            return new ResponseDto<Answer>(answer);
        }

        public async Task<ResponseDto<Answer>> DeleteAnswer(Guid id) {
            await _answerRepository.Delete(id);
            await _answerRepository.SaveChanges();
            return new ResponseDto<Answer>(null);
        }

    }
}