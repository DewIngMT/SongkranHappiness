using Microsoft.AspNetCore.Mvc;
using QuestionService.Models;
using QuestionService.Services;

namespace QuestionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionDataService _questionDataService;

        public QuestionController(QuestionDataService questionDataService)
        {
            _questionDataService = questionDataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return Ok(_questionDataService.GetQuestions());
        }

        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            var question = _questionDataService.GetQuestionById(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
    }
}