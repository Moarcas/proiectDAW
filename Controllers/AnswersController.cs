using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Services.AnswerService;

namespace proiectDAW.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService) {
            _answerService = answerService;
        }   

        // Get all answers for a question
        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetAllAnswersForQuestion(Guid questionId) {
            var answers = await _answerService.GetByQuestionId(questionId);
            if (answers.Success == false) {
                return BadRequest(new { message = answers.Message });
            }
            return Ok(answers.Data);
        }

        // Add an answer
        [HttpPost("add-answer")]
        public async Task<IActionResult> AddAnswer(AnswerDto answerDto) {
            System.Console.WriteLine("Add answer");
            if (HttpContext.Items.TryGetValue("userId", out object userId)) {
                var answer = new Answer {
                    userId = Guid.Parse(userId.ToString()),
                    questionId = answerDto.questionId,
                    content = answerDto.content,
                    createdAt = DateTime.UtcNow
                };
                
                var response = await _answerService.AddAnswer(answer);
                if (response.Success == true) {
                    return Ok(response.Data);
                }
            }
            return BadRequest(new { message = "Could not add answer" });
        }
    }
}