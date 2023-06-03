using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models;
using proiectDAW.Models.DTO;
using proiectDAW.Services.QuestionService;

namespace proiectDAW.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase {
        private readonly IQuestionService _questionService;
        
        public QuestionsController(IQuestionService questionService) {
            _questionService = questionService;
        }

        // Get all questions
        [HttpGet("questions")]
        public async Task<IActionResult> GetAllQuestions() {
            var questions = await _questionService.GetAll();
            if (questions.Success == false) {
                return BadRequest(new { message = questions.Message });
            }
            return Ok(questions.Data);
        }        

        // Add a question
        [HttpPost("add-question")]
        public async Task<IActionResult> AddQuestion(QuestionDto questionDto) {
            System.Console.WriteLine("AddQuestionController");
            if (HttpContext.Items.TryGetValue("userId", out object userId)) {
                var question = new Question {
                    userId = Guid.Parse(userId.ToString()),
                    title = questionDto.title,
                    content = questionDto.content,
                    createdAt = DateTime.UtcNow
                };

                var response = await _questionService.AddQuestion(question);
                if (response.Success == true) {
                    return Ok(response.Data);
                }
            }
            return BadRequest(new { message = "Could not add question" });
        }

    }
}