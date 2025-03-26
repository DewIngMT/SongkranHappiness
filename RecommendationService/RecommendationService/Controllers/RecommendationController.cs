using Microsoft.AspNetCore.Mvc;
using RecommendationService.Models;
using RecommendationService.Services;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly RecommendationLogicService _recommendationLogicService;

    public RecommendationController(RecommendationLogicService recommendationLogicService)
    {
        _recommendationLogicService = recommendationLogicService;
    }

    [HttpPost("process")]
    public ActionResult<RecommendationResult> ProcessAnswers([FromBody] List<Answer> answers)
    {
        if (answers == null || !answers.Any())
        {
            return BadRequest("ไม่พบคำตอบที่ส่งมา");
        }

        var result = _recommendationLogicService.GetRecommendations(answers);
        return Ok(result);
    }
}